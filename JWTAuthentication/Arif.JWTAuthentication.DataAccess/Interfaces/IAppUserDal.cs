using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Entities.Concrete;

namespace Arif.JWTAuthentication.DataAccess.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<List<AppRole>> GetRolesByUserNameAsync(string userName);
    }
}
