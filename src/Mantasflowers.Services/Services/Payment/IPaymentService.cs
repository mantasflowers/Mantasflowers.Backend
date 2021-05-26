using Mantasflowers.Contracts.Payment.Request;
using Mantasflowers.Contracts.Payment.Response;
using Stripe;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Payment
{
    public interface IPaymentService
    {
        Task<PostCreateCheckoutSessionResponse> CreateCheckoutSessionAsync(PostCreateCheckoutSessionRequest request, Guid? userId);

        Task<PostCreateCouponResponse> CreateCouponAsync(PostCreateCouponRequest request);

        Task SendEmailAsync(Event stripeEvent);
    }
}
