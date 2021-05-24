namespace Mantasflowers.Services.Services.Exceptions
{
    [System.Serializable]
    public class EmailSendFailedException : System.Exception
    {
        public EmailSendFailedException() { }
        public EmailSendFailedException(string message) : base(message) { }
        public EmailSendFailedException(string message, System.Exception inner) : base(message, inner) { }
        protected EmailSendFailedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}