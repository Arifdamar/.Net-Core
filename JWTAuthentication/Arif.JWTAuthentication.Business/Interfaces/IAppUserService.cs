using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Entities.Concrete;
using Arif.JWTAuthentication.Entities.Dtos.AppUserDtos;

namespace Arif.JWTAuthentication.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserName(string userName);
        Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto);
        Task<List<AppRole>> GetRolesByUserNameAsync(string userName);
    }
}
