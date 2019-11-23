using System;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace VideoDB.UnitTests
{
    [TestClass()]
    public class SqlDatabaseSetup
    {

        [AssemblyInitialize()]
        public static void InitializeAssembly(TestContext ctx)
        {
            if (ctx.Properties.Contains("override_connection_string"))
            {
                ChangeConfigFile("app.config", ctx);
                ChangeConfigFile($"{typeof(SqlDatabaseSetup).Assembly.GetName().Name}.dll.config", ctx);
            }
            // Setup the test database based on setting in the
            // configuration file
            SqlDatabaseTestClass.TestService.DeployDatabaseProject();
            SqlDatabaseTestClass.TestService.GenerateData();
        }

        private static void ChangeConfigFile(string filename, TestContext context)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                ["Data Source"] = context.Properties["db_source"] as string,
                ["Initial Catalog"] = context.Properties["db_catalog"] as string,
                ["User ID"] = context.Properties["db_username"] as string,
                ["Password"] = context.Properties["db_password"] as string,
                ["Authentication"] = "Active Directory Password",
                ["Persist Security Info"] = false,
                ["MultipleActiveResultSets"] = false,
                ["Encrypt"] = true,
                ["TrustServerCertificate"] = false,
                ["Connection Timeout"] = 30
            };

            var appConfig = XDocument.Load(filename);
            var unitTestSection = appConfig.Root
                .Elements()
                .First(f => f.Name == "SqlUnitTesting");

            var executionContext = unitTestSection.Elements()
                .First(f => f.Name == "ExecutionContext");

            var privilegedContext = unitTestSection.Elements()
                .First(f => f.Name == "PrivilegedContext");

            executionContext.Attributes()
                .First(f => f.Name == "ConnectionString")
                .Value = connectionStringBuilder.ConnectionString;

            privilegedContext.Attributes()
                .First(f => f.Name == "ConnectionString")
                .Value = connectionStringBuilder.ConnectionString;

            appConfig.Save(filename);
        }

    }
}
