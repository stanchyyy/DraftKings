using Book_lib.Models;
using Book_lib.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        [Given(@"\[HTTP client is initialized]")]
        public void GivenHTTPClientIsInitialized()
        {
            HttpClient HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:5000/");
            _scenarioContext.Set<HttpClient>(HttpClient);
        }
        [Given(@"\[User data is read]")]
        public void GivenUserDataIsRead(Table table)
        {
            UserModel UserModel = table.CreateInstance<UserModel>();
            _scenarioContext.Add("UserModel", UserModel);
        }

        [Given(@"\[Valid token obtained]")]
        public void GivenValidTokenObtained()
        {
            HttpClient httpClient = _scenarioContext.Get<HttpClient>("System.Net.Http.HttpClient");
            UserModel userModel = _scenarioContext.Get<UserModel>("UserModel");
            //rewrite the user services to be static and take http client and user as args
            TokenModel BearerToken = new UserServices(httpClient).SetNewUserAsync(userModel).Result;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", BearerToken.token);
            _scenarioContext.Set<HttpClient>(httpClient);
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