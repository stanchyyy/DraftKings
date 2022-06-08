using Book_lib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<BookModel>> GetBooksService()
        {
            var response = await Task.Run(() => HttpClient.GetAsync(HttpClient.BaseAddress + "Books"));
            response.EnsureSuccessStatusCode();
            string Contents = await response.Content.ReadAsStringAsync();

            return IEnumerable<JsonSerializer.Deserialize<BookModel>(Contents)>> ;
        }
    }
}