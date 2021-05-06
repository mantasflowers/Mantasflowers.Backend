using AutoMapper;
using Mantasflowers.Contracts.Payment.Request;
using Mantasflowers.Contracts.Payment.Response;
using Mantasflowers.Services.Services.Coupon;
using Mantasflowers.Services.Services.Order;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IOrderService _orderService;
        private readonly ICouponService _couponService;
        private readonly SessionService _stripeSessionService;
        private readonly Stripe.CouponService _stripeCouponService;
        private readonly PromotionCodeService _promotionCodeService;
        private readonly IMapper _mapper;

        public PaymentService(IOrderService orderService,
            ICouponService couponService,
            SessionService stripeSessionService,
            Stripe.CouponService stripeCouponService,
            PromotionCodeService promotionCodeService,
            IMapper mapper)
        {
            _orderService = orderService;
            _couponService = couponService;
            _stripeSessionService = stripeSessionService;
            _stripeCouponService = stripeCouponService;
            _promotionCodeService = promotionCodeService;
            _mapper = mapper;
        }

        public async Task<PostCreateCheckoutSessionResponse> CreateCheckoutSessionAsync(PostCreateCheckoutSessionRequest request)
        {
            var executionStrategy = _orderService.CreateExecutionStrategy();

            /**
             * As a unit of repetition
             * Read more on: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-resilient-entity-framework-core-sql-connections
             */
            var response = await executionStrategy.ExecuteAsync(() => CreateCheckoutSessionBodyAsync(request));

            return response;
        }

        private async Task<PostCreateCheckoutSessionResponse> CreateCheckoutSessionBodyAsync(PostCreateCheckoutSessionRequest request)
        {
            using var transaction = await _orderService.BeginTransactionAsync();
            var session = new Session();

            try
            {
                var order = await _orderService.CreateOrderAsync(request.Order);
                order = await _orderService.GetDetailedOrderAsync(order.Id); // Is there a better solution?

                var lineItems = new List<SessionLineItemOptions>();

                foreach (var orderItem in order.OrderItems)
                {
                    lineItems.Add(
                        new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmountDecimal = decimal.Round(
                                    orderItem.UnitPrice, 2,
                                    MidpointRounding.AwayFromZero
                                    ) * 100, // why stripe
                                Currency = "eur",
                                ProductData = new SessionLineItemPriceDataProductDataOptions
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
                    Mode = "payment",
                    LineItems = lineItems,
                    SuccessUrl = request.SuccessUrl,
                    CancelUrl = request.CancelUrl
                };

                options.AddExtraParam("allow_promotion_codes", "true");

                session = await _stripeSessionService.CreateAsync(options);

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
            var executionStrategy = _couponService.CreateExecutionStrategy();

            var response = await executionStrategy.ExecuteAsync(() => CreateCouponBodyAsync(request));

            return response;
        }

        private async Task<PostCreateCouponResponse> CreateCouponBodyAsync(PostCreateCouponRequest request)
        {
            using var transaction = await _couponService.BeginTransactionAsync();
            var promotionCode = new PromotionCode();

            try
            {
                request.RedeemBy = request.RedeemBy.Date;
                request.BeginDate = DateTime.Today;
                var coupon = await _couponService.CreateCouponAsync(request);

                var couponOptions = new CouponCreateOptions()
                {
                    Id = coupon.Id.ToString(),
                    Name = coupon.Name,
                    AmountOff = (long)coupon.DiscountPrice,
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
                    Restrictions = new PromotionCodeRestrictionsOptions()
                    {
                        MinimumAmount = (long)coupon.OrderOverPrice,
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
    }
}
