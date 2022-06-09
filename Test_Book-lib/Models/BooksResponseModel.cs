using Book_lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test_Book_lib.Models
{
    public class BooksResponseModel
    {
        [JsonPropertyName("books")]
        public List<BookModel> Books { get; set; }

        [JsonPropertyName("pageInfo")]
        public string PageInfo { get; set; }
        
    }
}
