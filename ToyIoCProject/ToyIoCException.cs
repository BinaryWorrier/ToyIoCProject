using System.Runtime.Serialization;

namespace ToyIoCProject
{
    [Serializable]
    internal class ToyIoCException : Exception
    {
        public ToyIoCException()
        {
        }

        public ToyIoCException(string? message) : base(message)
        {
        }

        public ToyIoCException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ToyIoCException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}