using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace VideoDB.WebApi.Extensions
{
    public static class IConfigurationExtensions
    {
        public static string CreateConnectionString(this IConfiguration configuration)
        {
            string connectionString;
            var overrideConnectionString = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("db_catalog"));

            if (overrideConnectionString)
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder()
                {
                    ["Data Source"] = Environment.GetEnvironmentVariable("db_source"),
                    ["Initial Catalog"] = Environment.GetEnvironmentVariable("db_catalog"),
                    ["User ID"] = Environment.GetEnvironmentVariable("db_username"),
                    ["Password"] = Environment.GetEnvironmentVariable("db_password"),
                    ["Authentication"] = "Active Directory Password",
                    ["Persist Security Info"] = false,
                    ["MultipleActiveResultSets"] = false,
                    ["Encrypt"] = true,
                    ["TrustServerCertificate"] = false,
                    ["Connection Timeout"] = 30
                };

                connectionString = connectionStringBuilder.ConnectionString;
            }
            else
            {
                connectionString = configuration.GetConnectionString("npdb");
            }

            return connectionString;
        }
    }
}
