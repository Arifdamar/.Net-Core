using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Business.Consts;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.Entities.Concrete;

namespace Arif.JWTAuthentication.WebApi
{
    public static class JwtIdentityInitializer
    {
        public static async Task SeedAsync(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByNameAsync(RoleInfo.Admin);

            if (adminRole == null)
            {
                await appRoleService.AddAsync(new AppRole() { Name = RoleInfo.Admin });
            }

            var memberRole = await appRoleService.FindByNameAsync(RoleInfo.Member);

            if (memberRole == null)
            {
                await appRoleService.AddAsync(new AppRole() { Name = RoleInfo.Member });
            }

            var adminUser = await appUserService.FindByUserNameAsync(RoleInfo.AdminUserName);

            if (adminUser == null)
            {
                await appUserService.AddAsync(new AppUser()
                {
                    FullName = RoleInfo.AdminFullName,
                    UserName = RoleInfo.AdminUserName,
                    Password = RoleInfo.AdminPassword
                });

                var role = await appRoleService.FindByNameAsync(RoleInfo.Admin);
                var admin = await appUserService.FindByUserNameAsync(RoleInfo.AdminUserName);

                await appUserRoleService.AddAsync(new AppUserRole()
                {
                    AppRoleId = role.Id,
                    AppUserId = admin.Id
                });
            }
        }
    }
}
