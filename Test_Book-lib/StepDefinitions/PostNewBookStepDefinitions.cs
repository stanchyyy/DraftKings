using Book_lib.Models;
using Book_lib.Services;
using System;
using TechTalk.SpecFlow;

namespace Test_Book_lib.StepDefinitions
{

    [Binding]
    public class PostNewBookStepDefinitions
    {
        private HttpClient? ClientApi;

        private string? UserName;

        private string? Password;

        private string? EmailAddress;

        private string? ApiToken;

        [Given(@"\[Book not present in the library]")]
        public async void GivenBookNotPresentInTheLibrary()
        {
            UserName = Environment.GetEnvironmentVariable("bookLibUsername", EnvironmentVariableTarget.User);
            Password = Environment.GetEnvironmentVariable("bookLibPassword", EnvironmentVariableTarget.User);
            EmailAddress = Environment.GetEnvironmentVariable("bookLibEmailAddress", EnvironmentVariableTarget.User);
            UserModel user = new UserModel(UserName, Password, EmailAddress);

            ClientApi = new HttpClient();
            ClientApi.BaseAddress = new Uri("http://localhost:5000/");
            UserServices userServices = new UserServices(ClientApi);
            ApiToken = await userServices.StartNewUserTestsAsync(user);
            BookModel Book = new();
        }

        [When(@"\[I login]")]
        public void WhenILogin()
        {
            Console.WriteLine("to be impelemnted");
        }

        [Then(@"\[I get authorization token]")]
        public void ThenIGetAuthorizationToken()
        {
            Console.WriteLine("to be impelemnted");
        }
    }
}
