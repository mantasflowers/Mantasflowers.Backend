namespace Mantasflowers.Services.ServiceAgents.Exceptions
{
    [System.Serializable]
    public class OrderNotFoundException : System.Exception
    {
        public OrderNotFoundException() { }
        public OrderNotFoundException(string message) : base(message) { }
        public OrderNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected OrderNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
