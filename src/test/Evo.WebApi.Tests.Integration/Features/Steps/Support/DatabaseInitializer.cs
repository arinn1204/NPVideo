using TechTalk.SpecFlow;

namespace Evo.WebApi.Tests.Integration.Features.Steps.Support
{
    [Binding]
    public class DatabaseInitializer
    {
        public DatabaseInitializer()
        {
        }

        [BeforeScenario]
        public void SetupDatabaseEntry()
        {
        }

        [AfterScenario]
        public void DestroyDatabaseEntries()
        {
        }
    }
}