using System.Collections.Generic;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.DataAccess.Interfaces;
using Arif.JWTAuthentication.Entities.Concrete;
using Arif.JWTAuthentication.Entities.Dtos.AppUserDtos;

namespace Arif.JWTAuthentication.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) : base(genericDal)
        {
            _appUserDal = appUserDal;
        }

        public async Task<AppUser> FindByUserNameAsync(string userName)
        {
            var appUser = await _appUserDal.GetByFilterAsync(I => I.UserName == userName);

            return appUser;
        }

        public async Task<bool> CheckPasswordAsync(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserDal.GetByFilterAsync(I => I.UserName == appUserLoginDto.UserName);

            return appUser.Password == appUserLoginDto.Password;
        }

        public async Task<List<AppRole>> GetRolesByUserNameAsync(string userName)
        {
            return await _appUserDal.GetRolesByUserNameAsync(userName);
        }
    }
}
