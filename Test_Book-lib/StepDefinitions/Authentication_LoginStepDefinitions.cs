using Book_lib.Models;
using Book_lib.Services;
using System;
using TechTalk.SpecFlow;

namespace Test_Book_lib.StepDefinitions
{
    [Binding]
    public class Authentication_LoginStepDefinitions
    {
        [Given(@"\[Create the user]")]

        HttpClient Client = new HttpClient();
        public async void GivenCreateTheUserAsync()
        {
            User user = new User("stanislav", "stanislav", "stanislav@stanislav.stanislav");
            UserServices userServices = new UserServices();
            await userServices.AddUserAsync(user);
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
