namespace Mantasflowers.Services.Services.Exceptions
{
    public class FailedToCreateCheckoutSessionException : System.Exception
    {
        public FailedToCreateCheckoutSessionException() { }
        public FailedToCreateCheckoutSessionException(string message) : base(message) { }
        public FailedToCreateCheckoutSessionException(string message, System.Exception inner) : base(message, inner) { }
        protected FailedToCreateCheckoutSessionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
