namespace Mantasflowers.Services.Services.Exceptions
{
    [System.Serializable]
    public class ConcurrentEntityUpdateException : System.Exception
    {
        public ConcurrentEntityUpdateException() { }
        public ConcurrentEntityUpdateException(string message) : base(message) { }
        public ConcurrentEntityUpdateException(string message, System.Exception inner) : base(message, inner) { }
        protected ConcurrentEntityUpdateException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}