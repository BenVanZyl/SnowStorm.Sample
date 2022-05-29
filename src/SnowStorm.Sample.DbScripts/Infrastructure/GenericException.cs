using System.Runtime.Serialization;

namespace SnowStormSample.DbScripts.Infrastructure
{
    [Serializable]
    public class GenericException : Exception
    {
        public GenericException()
        {
        }

        public GenericException(string? message) : base(message)
        {
        }

        public GenericException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GenericException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}