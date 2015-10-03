using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MasterCard.SDK
{
    [Serializable]
    public class MCApiRuntimeException : Exception, ISerializable
    {
        public MCApiRuntimeException()
            : base()
        {
            // Same as base Class
        }
        public MCApiRuntimeException(string message)
            : base(message)
        {
            // Same as base Class
        }
        public MCApiRuntimeException(string message, Exception inner)
            : base(message, inner)
        {
            // Same as base Class
        }

        // This constructor is needed for serialization. 
        protected MCApiRuntimeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Same as base Class
        }

    }
}
