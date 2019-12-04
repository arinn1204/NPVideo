using System;

namespace Evo.WebApi.Exceptions
{
    public class EvoBadRequestException : EvoException
    {
        public EvoBadRequestException(string message) : base(message) {}
        public EvoBadRequestException(string message, Exception innerException) : base(message, innerException) {}
    }
}