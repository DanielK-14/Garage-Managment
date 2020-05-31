using System;
using System.Runtime.Serialization;

namespace Ex03.GarageLogic
{
    [Serializable]
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException()
        {
        }

        public ValueOutOfRangeException(string message) : base(message)
        {
        }

        public ValueOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValueOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}