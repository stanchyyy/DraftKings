using Book_lib.Models;
using Book_lib.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Test_Book_lib.Drivers;

namespace Test_Book_lib.Hooks
{
    [Binding]
    public sealed class AddNewBookHook
    {
        private readonly ScenarioContext _scenarioContext;

        public AddNewBookHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [BeforeScenario(Order = 1)]

        [Given(@"\[HTTP client is initialized]")]
        public void GivenHTTPClientIsInitialized()
        {
            HttpClient HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:5000/");
            _scenarioContext.Set<HttpClient>(HttpClient);
        }
        [BeforeScenario(Order = 2)]
        [Given(@"\[User data is read]")]
        public void ReadUserData()
        {
            string UserNameVariable = "bookLibUsername";
            string PasswordVariable = "bookLibPassword";
            string EmailAddressVariavble = "bookLibEmailAddress";

            string UserName = Environment.GetEnvironmentVariable(UserNameVariable);
            if (UserName==null)
            {
                Environment.SetEnvironmentVariable(UserNameVariable, "specflowTest");
                UserName = Environment.GetEnvironmentVariable(UserNameVariable);
            }

            string Password = Environment.GetEnvironmentVariable(PasswordVariable);
            if (Password == null)
            {
                Environment.SetEnvironmentVariable(PasswordVariable, "specflowTest");
                Password = Environment.GetEnvironmentVariable(PasswordVariable);
            }

            string EmailAddress = Environment.GetEnvironmentVariable(EmailAddressVariavble);
            {
                Environment.SetEnvironmentVariable(EmailAddressVariavble, "spec@spec.flow");
                Password = Environment.GetEnvironmentVariable(EmailAddressVariavble);
            }

            UserModel UserModel = new(UserName,Password,EmailAddress);

            _scenarioContext.Add("UserModel", UserModel);
        }
        [BeforeScenario(Order = 3)]
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

        [BeforeScenario(Order = 4)]
        [Given(@"\[Database context is created]")]
        public void GivenDatabaseContextIsCreated()
        {
            DatabaseDriver DatabaseDriver = new();
            _scenarioContext.Add("DatabaseDriver", DatabaseDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}