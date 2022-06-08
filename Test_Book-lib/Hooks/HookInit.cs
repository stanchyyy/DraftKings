using Book_lib.Models;
using Book_lib.Services;
using TechTalk.SpecFlow;

namespace Test_Book_lib.Hooks
{
    [Binding]
    public sealed class HookInit
    {
        private readonly ScenarioContext _scenarioContext;

        public HookInit(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("@TodoApp")]



        public void BeforeScenarioWithTag()
        {
            //will move this initialization to dependecy injection once working with hardcoded values.Will replace environmental variables with table.
            string UserName = Environment.GetEnvironmentVariable("bookLibUsername", EnvironmentVariableTarget.User);
            string Password = Environment.GetEnvironmentVariable("bookLibPassword", EnvironmentVariableTarget.User);
            string EmailAddress = Environment.GetEnvironmentVariable("bookLibEmailAddress", EnvironmentVariableTarget.User);
            UserModel User = new(UserName, Password, EmailAddress);

            HttpClient HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:5000/");
            TokenModel BearerToken = new UserServices(HttpClient).StartNewUserTestsAsync(User).Result;
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", BearerToken.token);
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}