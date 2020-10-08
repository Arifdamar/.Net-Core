using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Entities.Concrete;

namespace Arif.JWTAuthentication.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserName(string userName);
        Task<bool> CheckPassword(string userName, string password);
    }
}
