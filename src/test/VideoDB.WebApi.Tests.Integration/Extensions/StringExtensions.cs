using Newtonsoft.Json;

namespace Evo.WebApi.Tests.Integration.Extensions
{
    public static class StringExtensions
    {
        public static T DeserializeTo<T>(this string @this)
        {
            return JsonConvert.DeserializeObject<T>(@this);
        }
    }
}