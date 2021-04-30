using AutoMapper;
using Mantasflowers.Contracts.Payment.Response;
using Stripe.Checkout;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Session, PostCreateCheckoutSessionResponse>();
        }
    }
}
