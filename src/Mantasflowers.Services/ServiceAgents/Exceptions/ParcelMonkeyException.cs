using System;
using System.Runtime.Serialization;

namespace Mantasflowers.Services.ServiceAgents.Exceptions
{
    [Serializable]
    public class ParcelMonkeyException : Exception
    {
        public ParcelMonkeyException() { }
        public ParcelMonkeyException(string message) : base(message) { }
        public ParcelMonkeyException(string message, Exception inner) : base(message, inner) { }
        protected ParcelMonkeyException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
