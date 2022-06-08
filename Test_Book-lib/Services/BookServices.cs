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
        private static string JsonTemplateFileName
        {
            get{ return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..", "Templates", "newBookTemplate.json")); }
        }

        public List<BookModel> GetBooksFromTemplateService()
        {
            List<BookModel> TemplateBooks = new();
            using (var reader = File.OpenText(JsonTemplateFileName))
            {
                string readText = reader.ReadToEnd();
                return TemplateBooks = JsonSerializer.Deserialize<List<BookModel>>(readText);
            }
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
    }
}