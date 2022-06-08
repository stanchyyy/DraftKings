using Book_lib.Models;
using Book_lib.Services;
using System;
using TechTalk.SpecFlow;

namespace Test_Book_lib.StepDefinitions
{

    [Binding]
    public class PostNewBookStepDefinitions
    {
        public HttpClient HttpClient { get; set; }

        private string? UserName;

        private string? Password;

        private string? EmailAddress;

        private UserModel? UserModel;

        private TokenModel? BearerToken;

        [Given(@"User is signed in")]
        public void GivenUserIsSignedIn(Table table)
        {
            UserName = Environment.GetEnvironmentVariable("bookLibUsername", EnvironmentVariableTarget.User);
            Password = Environment.GetEnvironmentVariable("bookLibPassword", EnvironmentVariableTarget.User);
            EmailAddress = Environment.GetEnvironmentVariable("bookLibEmailAddress", EnvironmentVariableTarget.User);
            UserModel = new(UserName, Password, EmailAddress);
        }



        public void GivenHTTPClientInitialized()
        {
            //consider having a services for the HTTP?
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:5000/");
        }



        public async void GivenBookNotPresentInTheLibrary()
        {
           
            //BearerToken = await new UserServices(HttpClient).StartNewUserTestsAsync();
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", BearerToken.token);
            BookServices BookServices = new BookServices(HttpClient);
            BookServices.AddBookService(BookServices.GetBooksFromTemplateService());

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
