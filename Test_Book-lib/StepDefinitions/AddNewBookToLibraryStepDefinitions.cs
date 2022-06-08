using Book_lib.Models;
using System;
using TechTalk.SpecFlow;

namespace Test_Book_lib.StepDefinitions
{
    [Binding]
    public class AddNewBookToLibraryStepDefinitions
    {
        [Given(@"\[the books are not present in the library]")]
        public void GivenTheBooksAreNotPresentInTheLibrary(Table table)
        {
            List<BookModel> books = new List<BookModel>();
        }
    }
}
