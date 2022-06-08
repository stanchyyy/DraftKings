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
        public HttpClient HttpClient { get; set; }
        public UserServices(HttpClient httpClient) => HttpClient = httpClient;


        public async Task AddUserAsync(UserModel user)
        {
            {
                string JsonUserString = JsonSerializer.Serialize(user);
                var response = await Task.Run(()=> HttpClient.PostAsync(HttpClient.BaseAddress+"Authentication/create-user", new StringContent(JsonUserString, Encoding.UTF8, "application/json")));
                response.EnsureSuccessStatusCode();
            }
        }
        //Found in documentation that delete with body is not a well developed API - not restful.
        public async Task DeleteUserAsync(UserDeleteModel user)
        {
            string JsonUserDeleteString = JsonSerializer.Serialize(user);
            HttpRequestMessage HttpMessage = new (HttpMethod.Delete, HttpClient.BaseAddress + "Authentication/delete-user")
            {
               Content = new StringContent(JsonUserDeleteString, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = await HttpClient.SendAsync(HttpMessage);
            response.EnsureSuccessStatusCode();
        }

        public async Task<TokenModel> LoginUserAsync(UserLoginModel user)
        {
            string JsonUserString = JsonSerializer.Serialize(user);
            StringContent LoginContent = new StringContent(JsonUserString, Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await Task.Run(() => HttpClient.PostAsync(HttpClient.BaseAddress + "Authentication/login",LoginContent));
            Response.EnsureSuccessStatusCode();
            string Contents = await Response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TokenModel>(Contents);
        }

        public async Task<TokenModel> StartNewUserTestsAsync(UserModel user)
        {
            {
                await DeleteUserAsync(new UserDeleteModel(user.EmailAddress));
                await AddUserAsync(user);
                return await LoginUserAsync(new UserLoginModel(user.EmailAddress,user.Password));
            }
        }


    }
}
