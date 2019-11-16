using System.Net.Http;
using System.Threading.Tasks;

namespace Evo.WebApi.Tests.Integration.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<string> GetContent(this HttpResponseMessage @this)
        {
            return await @this.Content.ReadAsStringAsync();
        }
    }
}