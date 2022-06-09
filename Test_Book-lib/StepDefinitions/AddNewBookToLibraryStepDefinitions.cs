using Book_lib.Models;
using Book_lib.Services;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Test_Book_lib.StepDefinitions
{
    [Binding]
    public class AddNewBookToLibraryStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public AddNewBookToLibraryStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }



        [Given(@"\[the books are not present in the library]")]
        public void GivenTheBooksAreNotPresentInTheLibrary(Table table)
        {
            //does not populate the author - needs deeper understanding how to destructure the data. Author-book match is not guaranteed.
            IEnumerable<BookModel> books = table.CreateSet<BookModel>();
            IEnumerable<AuthorModel> authors = table.CreateSet<AuthorModel>();
            foreach (var author in authors)
            {
                foreach (var book in books)
                {
                    book.Author = author;
                }
            }
            BookServices bookServices = new(_scenarioContext.Get<HttpClient>("System.Net.Http.HttpClient"));
            var result = bookServices.GetBooksService().Result;
        }
    }
}
