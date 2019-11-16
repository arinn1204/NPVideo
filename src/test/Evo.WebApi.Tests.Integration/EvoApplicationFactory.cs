using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evo.WebApi.Tests.Integration
{
    public class EvoApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        private readonly IConfiguration _connection;

        public EvoApplicationFactory(IConfiguration connection)
        {
            _connection = connection;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.PostConfigure<SqlConnection>(
                    conn => conn.ConnectionString = _connection.GetConnectionString("Evo"));
            });
        }
    }
}