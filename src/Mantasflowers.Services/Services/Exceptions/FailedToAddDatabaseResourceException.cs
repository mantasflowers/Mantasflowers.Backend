namespace Mantasflowers.Services.Services.Exceptions
{
    [System.Serializable]
    public class FailedToAddDatabaseResourceException : System.Exception
    {
        public FailedToAddDatabaseResourceException() { }
        public FailedToAddDatabaseResourceException(string message) : base(message) { }
        public FailedToAddDatabaseResourceException(string message, System.Exception inner) : base(message, inner) { }
        protected FailedToAddDatabaseResourceException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}