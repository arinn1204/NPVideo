using System;

namespace Evo.WebApi.Exceptions
{
    public class EvoNotFoundException : EvoException
    {
        public EvoNotFoundException(string message) : base(message) {}
        public EvoNotFoundException(string message, Exception innerException) : base(message, innerException) {}
    }
}