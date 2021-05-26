using System;
using System.Runtime.Serialization;

namespace Mantasflowers.Services.ServiceAgents.Exceptions
{
    [Serializable]
    public class MultiParcelException : Exception
    {
        public MultiParcelException() { }
        public MultiParcelException(string message) : base(message) { }
        public MultiParcelException(string message, Exception inner) : base(message, inner) { }
        protected MultiParcelException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
