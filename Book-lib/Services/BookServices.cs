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

        public async Task<List<BookModel>> CreateBooksFromTemplate()
        {
            List<BookModel> TemplateBookModel = new();
            using (StringReader reader = new StringReader("./Templates/newBookTemplate.json"))
            {
                string readText = await reader.ReadToEndAsync();
                TemplateBookModel = JsonSerializer.Deserialize<List<BookModel>>(readText);
            }

            return TemplateBookModel;
        }
        
    }
}