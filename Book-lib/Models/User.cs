using System.Text.Json;
using System.Text.Json.Serialization;

namespace Book_lib.Models
{
    public class User
    {

        private string password;


        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get => password; private set => password = value; }
        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        public User(string userName, string password, string emailAddress)
        {
            UserName = userName;
            Password = password;
            EmailAddress = emailAddress;
        }

        public override string ToString() => JsonSerializer.Serialize<User>(this);
    }

}