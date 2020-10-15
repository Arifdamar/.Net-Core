using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using JWTAuthentication_Front.ApiServices.Interfaces;
using JWTAuthentication_Front.Models;

namespace JWTAuthentication_Front.ApiServices.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IHttpContextAccessor _accessor;
        public AuthManager(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public async Task<HttpResponseMessage> GetActiveUser(string token)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await httpClient.GetAsync("http://localhost:10188/api/Auth/ActiveUser");
        }

        //HttpContext
        public async Task<bool> LogIn(AppUserLogin appUserLogin)
        {
            string jsonData = JsonConvert.SerializeObject(appUserLogin);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:10188/api/Auth/SignIn", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                var token = JsonConvert.DeserializeObject<AccessToken>(await responseMessage.Content.ReadAsStringAsync());
                _accessor.HttpContext.Session.SetString("token", token.Token);

                return true;
            }
            else
            {
                return false;
            }
        }

        public void LogOut()
        {
            _accessor.HttpContext.Session.Remove("token");
        }
    }
}