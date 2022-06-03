using System.Net.Http.Headers;
using System.Threading.Tasks;
using static Book_lib.WebAPIClientHelper;


namespace Book_lib.Authentication
{
    public class CreateUser
    {
        string RequestBody = "{ 'userName': 'stringd',  'emailAddress': 'sysstring@abv.bgd',  'password': 'stringstring'}";

        private string password;

        public string UserName { get; set; }
        public string Password { get => password; private set => password = value; }
        public string EmailAddress { get; set; }

        private static async Task NewUser()
        {
            client.PostAsync()

        }
    }
}