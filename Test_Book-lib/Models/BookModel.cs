using System;
using System.Text.Json.Serialization;

namespace Book_lib.Models
{
    public class BookModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public BookAuthorModel Author { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("releaseDate")]
        public DateTime ReleaseDate { get; set; }
    }
}