using System;
using System.Runtime.Serialization;

namespace Mantasflowers.Services.ServiceAgents.Exceptions
{
    [Serializable]
    public class FirebaseTokenException : Exception
    {
        public FirebaseTokenException() { }
        public FirebaseTokenException(string message) : base(message) { }
        public FirebaseTokenException(string message, Exception inner) : base(message, inner) { }
        protected FirebaseTokenException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
