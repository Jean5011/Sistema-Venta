using System;
using System.Runtime.Serialization;

namespace Sistema_de_ventas
{
    [Serializable]
    internal class exeption : Exception
    {
        public exeption()
        {
        }

        public exeption(string message) : base(message)
        {
        }

        public exeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected exeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}