using System;
using System.Runtime.Serialization;

namespace Mantasflowers.Services.Services.Exceptions
{
    [Serializable]
    public class HashMapOrderNotFoundException : Exception
    {
        public HashMapOrderNotFoundException() { }
        public HashMapOrderNotFoundException(string message) : base(message) { }
        public HashMapOrderNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected HashMapOrderNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
