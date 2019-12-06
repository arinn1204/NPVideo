using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoDB.WebApi.Extensions;

namespace VideoDB.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/[controller]")]
    public class HealthcheckController : Controller
    {
        private readonly IConfiguration _configuration;

        public HealthcheckController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Healthcheck()
        {
            var information = GetSqlInformation();

            return Ok(new
            {
                AddedVariable = Environment.GetEnvironmentVariable("SampleApplicationVariable"),
                DbName = information.First(),
                DbVersion = information.Skip(1).First()
            });
        }

        private IEnumerable<string> GetSqlInformation()
        {
            var information = Enumerable.Empty<string>();

            var connectionString = _configuration.CreateConnectionString();
            using var connection = new SqlConnection(connectionString);
            using var sqlCmd = new SqlCommand("SELECT DB_NAME(), @@VERSION", connection);

            sqlCmd.Connection.Open();
            var reader = sqlCmd.ExecuteReader();
            reader.Read();
            information = information.Append(reader.GetString(0));
            information = information.Append(reader.GetString(1));
            information = information.Append(reader.GetString(2));

            return information;
        }
    }
}
