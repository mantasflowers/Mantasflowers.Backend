namespace Mantasflowers.Services.Services.Exceptions
{
    [System.Serializable]
    public class ProductNotFoundException : System.Exception
    {
        public ProductNotFoundException() { }
        public ProductNotFoundException(string message) : base(message) { }
        public ProductNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected ProductNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}