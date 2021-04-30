﻿using AutoMapper;
using Mantasflowers.Contracts.Payment.Request;
using Mantasflowers.Contracts.Payment.Response;
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
        private readonly IMapper _mapper;

        public PaymentService(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<PostCreateCheckoutSessionResponse> CreateCheckoutSession(PostCreateCheckoutSessionRequest request)
        {
            var executionStrategy = _orderService.CreateExecutionStrategy();

            /**
             * As a unit of repetition
             * Read more on: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-resilient-entity-framework-core-sql-connections
             */
            var response = await executionStrategy.ExecuteAsync(() => CreateCheckoutSessionBody(request));

            return response;
        }

        private async Task<PostCreateCheckoutSessionResponse> CreateCheckoutSessionBody(PostCreateCheckoutSessionRequest request)
        {
            using var transaction = await _orderService.BeginTransactionAsync();
            var session = new Session();

            try
            {
                var order = await _orderService.CreateOrderAsync(request.Order);

                var lineItems = new List<SessionLineItemOptions>();

                foreach (var orderItem in order.OrderItems)
                {
                    lineItems.Add(
                        new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmountDecimal = orderItem.UnitPrice * 100, // why stripe
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
                    CancelUrl = request.Cancelurl
                };

                var service = new SessionService();

                session = service.Create(options);

                await transaction.CommitAsync();
            }
            catch (StripeException e)
            {
                // TODO
                Console.WriteLine(e.StripeError);
                await transaction.RollbackAsync();
            }

            var response = _mapper.Map<PostCreateCheckoutSessionResponse>(session);
            return response;
        }
    }
}
