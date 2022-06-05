using Book_lib.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book_lib.Services
{
    public class UserServices
    {
        public User User { get; set; }
        public HttpClient HttpClient { get; set; }
        public string JsonUserString { get; set; }


        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public UserServices(HttpClient httpClient) => HttpClient = httpClient;


        public async Task AddUserAsync(User user)
        {
            {
                User = user;
                string JsonUserString = JsonSerializer.Serialize(user, options);
                var response = await Task.Run(()=> HttpClient.PostAsync(HttpClient.BaseAddress+"/Authentication/create-user", new StringContent(JsonUserString, Encoding.UTF8, "application/json")));
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteUserAsync(string emailAddress) 
        {
            var response = await Task.Run(() => HttpClient.DeleteAsync(HttpClient.BaseAddress+"/Authentication/delete-user"));
            response.EnsureSuccessStatusCode();
        }

    

        public async Task<string> LoginUserAsync(string emailAddress, string password)
        {
            Dictionary<string,string> LoginData = new Dictionary<string,string>();
            LoginData.Add("email", emailAddress);
            LoginData.Add("password", password);
            string JsonUserString = JsonSerializer.Serialize(LoginData, options);

            var LoginContent = new StringContent(JsonUserString);




            var response = await Task.Run(() => HttpClient.PostAsync(HttpClient.BaseAddress + "/Authentication/login",LoginContent));
            response.EnsureSuccessStatusCode();
            return response.ToString();
        }

    }
}
