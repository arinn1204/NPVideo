using System;

namespace Evo.WebApi.Exceptions
{
    public class EvoBadRequestException : Exception
    {
        public EvoBadRequestException()
        {
        }

        public EvoBadRequestException(string message)
            : base(message)
        {
        }
    }
}