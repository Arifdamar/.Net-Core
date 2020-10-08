﻿using System.Threading.Tasks;
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

        public async Task<AppUser> FindByUserName(string userName)
        {
            var appUser = await _appUserDal.GetByFilterAsync(I => I.UserName == userName);

            return appUser;
        }

        public async Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserDal.GetByFilterAsync(I => I.UserName == appUserLoginDto.UserName);

            return appUser.Password == appUserLoginDto.Password;
        }
    }
}
