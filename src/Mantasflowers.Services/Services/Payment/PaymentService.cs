using AutoMapper;
using Mantasflowers.Contracts.Email.Request;
using Mantasflowers.Contracts.Payment.Request;
using Mantasflowers.Contracts.Payment.Response;
using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Services.Coupon;
using Mantasflowers.Services.Services.Email;
using Mantasflowers.Services.Services.Exceptions;
using Mantasflowers.Services.Services.Order;
using Mantasflowers.Services.Services.Shipment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly ICouponService _couponService;
        private readonly IEmailService _emailService;
        private readonly IShipmentService _shipmentService;
        private readonly SessionService _stripeSessionService;
        private readonly Stripe.CouponService _stripeCouponService;
        private readonly CustomerService _customerService;
        private readonly PromotionCodeService _promotionCodeService;
        private readonly ShippingRate _shippingRate;
        private readonly IMapper _mapper;

        public PaymentService(
            IUnitOfWork unitOfWork,
            IOrderService orderService,
            ICouponService couponService,
            IEmailService emailService,
            IShipmentService shipmentService,
            SessionService stripeSessionService,
            Stripe.CouponService stripeCouponService,
            CustomerService customerService,
            PromotionCodeService promotionCodeService,
            IOptions<ShippingRate> optionsAccessor,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _couponService = couponService;
            _customerService = customerService;
            _emailService = emailService;
            _shipmentService = shipmentService;
            _stripeSessionService = stripeSessionService;
            _stripeCouponService = stripeCouponService;
            _promotionCodeService = promotionCodeService;
            _shippingRate = optionsAccessor.Value;
            _mapper = mapper;
        }

        public async Task<PostCreateCheckoutSessionResponse> CreateCheckoutSessionAsync(PostCreateCheckoutSessionRequest request, Guid? userId)
        {
            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            /**
             * As a unit of repetition
             * Read more on: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-resilient-entity-framework-core-sql-connections
             */
            var response = await executionStrategy.ExecuteAsync(() => CreateCheckoutSessionBodyAsync(request, userId));

            return response;
        }

        private async Task<PostCreateCheckoutSessionResponse> CreateCheckoutSessionBodyAsync(PostCreateCheckoutSessionRequest request, Guid? userId)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            var session = new Session();

            try
            {
                var order = await _orderService.CreateOrderAsync(request.Order);
                await _unitOfWork.SaveChangesAsync();

                foreach (var item in order.OrderItems)
                {
                    if (item.Product.LeftInStock - item.Quantity <= 0)
                    {
                        throw new FailedToCreateCheckoutSessionException("Out of stock");
                    }
                    item.Product.LeftInStock -= item.Quantity;
                    _unitOfWork.ProductRepository.Update(item.Product);
                }

                if (userId.HasValue)
                {
                    await _orderService.LinkUserToOrderAsync(userId.Value, order);
                }

                var lineItems = new List<SessionLineItemOptions>();

                foreach (var orderItem in order.OrderItems)
                {
                    lineItems.Add(
                        new()
                        {
                            PriceData = new()
                            {
                                UnitAmountDecimal = decimal.Round(
                                    orderItem.UnitPrice, 2,
                                    MidpointRounding.AwayFromZero
                                    ) * 100, // why stripe
                                Currency = "eur",
                                ProductData = new()
                                {
                                    Name = orderItem.Product.Name,
                                    Description = orderItem.Product.ShortDescription,
                                    Images = new List<string> { orderItem.Product.ThumbnailPictureUrl }
                                }
                            },
                            Quantity = orderItem.Quantity
                        });
                }

                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    CustomerEmail = order.OrderContactInfo.Email,
                    Mode = "payment",
                    LineItems = lineItems,
                    SuccessUrl = request.SuccessUrl + $"password={order.UniquePassword}",
                    CancelUrl = request.CancelUrl,
                    AllowPromotionCodes = true,
                    ShippingAddressCollection = new()
                    {
                        AllowedCountries = new List<string>
                        {
                            "LT"
                        }
                    },
                    Locale = "lt",
                    ShippingRates = new List<string>()
                    {
                        _shippingRate.Value
                    } // currently only one is supported by stripe
                };

                session = await _stripeSessionService.CreateAsync(options);

                order.Payment = new();
                order.Payment.PaymentIntentId = session.PaymentIntentId;
                _unitOfWork.OrderRepository.Update(order);
                await _unitOfWork.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (StripeException)
            {
                await transaction.RollbackAsync();
                throw;
            }

            var response = _mapper.Map<PostCreateCheckoutSessionResponse>(session);
            return response;
        }

        public async Task<PostCreateCouponResponse> CreateCouponAsync(PostCreateCouponRequest request)
        {
            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            var response = await executionStrategy.ExecuteAsync(() => CreateCouponBodyAsync(request));

            return response;
        }

        private async Task<PostCreateCouponResponse> CreateCouponBodyAsync(PostCreateCouponRequest request)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            var promotionCode = new PromotionCode();

            try
            {
                request.RedeemBy = request.RedeemBy.Date;
                request.BeginDate = DateTime.Today;
                var coupon = await _couponService.CreateCouponAsync(request);
                await _unitOfWork.SaveChangesAsync();

                var couponOptions = new CouponCreateOptions()
                {
                    Id = coupon.Id.ToString(),
                    Name = coupon.Name,
                    AmountOff = (long)(coupon.DiscountPrice * 100),
                    Currency = "eur",
                    Duration = "repeating",
                    DurationInMonths = request.DurationInMonths,
                    RedeemBy = coupon.EndDate,
                };

                await _stripeCouponService.CreateAsync(couponOptions);

                // Hate stripe already
                var promoCodeOptions = new PromotionCodeCreateOptions()
                {
                    Coupon = coupon.Id.ToString(),
                    Code = coupon.Name,
                    Restrictions = new()
                    {
                        MinimumAmount = (long)(coupon.OrderOverPrice * 100),
                        MinimumAmountCurrency = "eur"
                    }
                };

                promotionCode = await _promotionCodeService.CreateAsync(promoCodeOptions);
                promotionCode.Created = promotionCode.Created.Date;

                await transaction.CommitAsync();
            }
            catch (StripeException)
            {
                await transaction.RollbackAsync();
                throw;
            }

            var response = _mapper.Map<PostCreateCouponResponse>(promotionCode);
            return response;
        }

        public async Task SendEmailAsync(Event stripeEvent)
        {
            var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

            var order = await _orderService.GetDetailedOrderAsync(paymentIntent.Id);

            if (order == null)
            {
                throw new OrderNotFoundException("No Order linked to PaymentIntent was found");
            }

            var emailRequest = _mapper.Map<SendEmailRequest>(order);
            emailRequest.PurchaseDate = paymentIntent.Created;
            var customer = await _customerService.GetAsync(paymentIntent.CustomerId);
            emailRequest.ClientFullName = customer.Name;

            await _emailService.SendEmailAsync(emailRequest);
        }
    }
}
