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
        private UserModel User { get; set; }
        private UserDeleteModel UserDelete { get; set; }
        private UserLoginModel UserLogin { get; set; }
        public HttpClient HttpClient { get; set; }

        public UserServices(HttpClient httpClient) => HttpClient = httpClient;


        private async Task AddUserAsync(UserModel userModel)
        {
            {
                User = userModel;
                string JsonUserString = JsonSerializer.Serialize(userModel);
                var response = await Task.Run(()=> HttpClient.PostAsync(HttpClient.BaseAddress+"Authentication/create-user", new StringContent(JsonUserString, Encoding.UTF8, "application/json")));
                response.EnsureSuccessStatusCode();
            }
        }
        //Found in documentation that delete with body is not a well developed API - not restful.
        private async Task DeleteUserAsync(UserDeleteModel userDeleteModel)
        {
            UserDelete = userDeleteModel;
            string JsonUserDeleteString = JsonSerializer.Serialize(UserDelete);
            HttpRequestMessage HttpMessage = new (HttpMethod.Delete, HttpClient.BaseAddress + "Authentication/delete-user")
            {
               Content = new StringContent(JsonUserDeleteString, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = await HttpClient.SendAsync(HttpMessage);
            response.EnsureSuccessStatusCode();
        }

    

        private async Task<string> LoginUserAsync(UserLoginModel userLogin)
        {
            UserLogin = userLogin;
            string JsonUserString = JsonSerializer.Serialize(UserLogin);
            StringContent LoginContent = new StringContent(JsonUserString, Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await Task.Run(() => HttpClient.PostAsync(HttpClient.BaseAddress + "Authentication/login",LoginContent));
            Response.EnsureSuccessStatusCode();
            string Contents = await Response.Content.ReadAsStringAsync();
            TokenModel ApiToken = JsonSerializer.Deserialize<TokenModel>(Contents);
            return ApiToken.token;
        }

        public async Task<string> StartNewUserTestsAsync(UserModel user)
        {
            {
                UserDeleteModel DeleteModel = new(user.EmailAddress);
                await this.DeleteUserAsync(DeleteModel);
                User = user;
                await this.AddUserAsync(User);
                UserLoginModel LoginModel = new(User.EmailAddress,user.Password);
                string Token = await this.LoginUserAsync(LoginModel);
                return Token;
            }
        }


    }
}
