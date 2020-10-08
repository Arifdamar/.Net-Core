using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arif.JWTAuthentication.DataAccess.Concrete.EntityFrameworkCore.Context;
using Arif.JWTAuthentication.DataAccess.Interfaces;
using Arif.JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Arif.JWTAuthentication.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public async Task<List<AppRole>> GetRolesByUserNameAsync(string userName)
        {
            await using var context = new JWTAuthContext();

            return await context.AppUsers
                .Join(context.AppUserRoles, u => u.Id, ur => ur.AppUserId,
                    (user, userRole) => new
                    {
                        user = user,
                        userRole = userRole
                    })
                .Join(context.AppRoles, uur => uur.userRole.AppRoleId, r => r.Id,
                    (userUserRole, role) => new
                    {
                        user = userUserRole.user,
                        userRole = userUserRole.userRole,
                        role = role
                    })
                .Where(I => I.user.UserName == userName)
                .Select(I => new AppRole()
                {
                    Id = I.role.Id,
                    Name = I.role.Name
                })
                .ToListAsync();
        }
    }
}
