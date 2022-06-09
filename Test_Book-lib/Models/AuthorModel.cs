using System;
using System.Text.Json.Serialization;

namespace Book_lib.Models
{
    public class AuthorModel
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string authorLastName { get; set; }

        [JsonPropertyName("lastName")]
        public string authorFirstName { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime authorDateOfBirth { get; set; }
    }
}