using System;
using System.Runtime.Serialization;

namespace Mantasflowers.Services.Services.Exceptions
{
    [Serializable]
    public class FirebaseUidNotFoundException : Exception
    {
        public FirebaseUidNotFoundException() { }
        public FirebaseUidNotFoundException(string message) : base(message) { }
        public FirebaseUidNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected FirebaseUidNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
