using Mantasflowers.Contracts.Order.Request;

namespace Mantasflowers.Contracts.Payment.Request
{
    public class PostCreateCheckoutSessionRequest
    {
        public PostCreateOrderRequest Order { get; set; }

        public string SuccessUrl { get; set; }

        public string Cancelurl { get; set; }
    }
}
