using Book_lib.Models;

using System.Text;
using System.Text.Json;

using Test_Book_lib.Models;

namespace Book_lib.Services
{
    public class BookServices
    {
        private BookModel BookModel;
        public HttpClient HttpClient { get; set; }


        public BookServices(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }


        public async void AddBookService(List<BookModel> bookModels)
        {
                foreach (BookModel book in bookModels)
                {
                    string JsonBookString = JsonSerializer.Serialize(book);
                    var response = await Task.Run(() => HttpClient.PostAsync(HttpClient.BaseAddress + "Books", new StringContent(JsonBookString, Encoding.UTF8, "application/json")));
                    response.EnsureSuccessStatusCode();
                }
        }

        public async void DeleteBookService(IEnumerable<BookModel> bookModels)
        {
            foreach (BookModel book in bookModels)
            {
                string JsonBookString = JsonSerializer.Serialize(book);
                var response = await Task.Run(() => HttpClient.PostAsync(HttpClient.BaseAddress + "Books", new StringContent(JsonBookString, Encoding.UTF8, "application/json")));
                response.EnsureSuccessStatusCode();
            }
        }
        public async Task<List<BooksResponseModel>>GetBooksService()
        {

            List<BooksResponseModel> AllBooks = new List<BooksResponseModel>();
            int pageIndex = 1;
            BooksResponseModel BooksOnPage = new();
            do
            {
                UriBuilder uri = new(HttpClient.BaseAddress+ "Books");
                string queryToAppend = "PageNumber="+pageIndex.ToString();
                uri.Query = queryToAppend;

                HttpResponseMessage response = await Task.Run(() => HttpClient.GetAsync(uri.ToString()));
                response.EnsureSuccessStatusCode();
                string PageContents = await response.Content.ReadAsStringAsync();
                BooksOnPage = JsonSerializer.Deserialize<BooksResponseModel>(PageContents);
                AllBooks.Add(BooksOnPage);
                pageIndex++;
                
            } while (BooksOnPage.Books.Count > 0);
            

            return AllBooks;
        }
    }
}