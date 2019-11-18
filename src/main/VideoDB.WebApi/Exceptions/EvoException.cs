using System;

namespace Evo.WebApi.Exceptions
{
    public class EvoException : Exception
    {
        public EvoException(string message) : base(message) {}
        public EvoException(string message, Exception innerException) : base(message, innerException) {}
    }
}