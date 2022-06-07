using Book_lib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book_lib.Services
{
    public class BookServices
    {
        public BookServices(BookModel bookModel)
        {

        }
        private static string JsonFileName
        {
            get{ return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..", "Templates", "newBookTemplate.json")); }
        }

        public static List<BookModel> CreateBooksFromTemplate()
        {
            List<BookModel> TemplateBookModel = new();
            using (var reader = File.OpenText(JsonFileName))
            {
                string readText = reader.ReadToEnd();
                return TemplateBookModel = JsonSerializer.Deserialize<List<BookModel>>(readText);
            }
        }
        
    }
}