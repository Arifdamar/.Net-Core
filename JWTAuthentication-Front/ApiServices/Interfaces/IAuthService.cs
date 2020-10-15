using System.Net.Http;
using System.Threading.Tasks;
using JWTAuthentication_Front.Models;

namespace JWTAuthentication_Front.ApiServices.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LogIn(AppUserLogin appUserLogin);

        Task<HttpResponseMessage> GetActiveUser(string token);
        void LogOut();
    }
}