using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.DataAccess.Interfaces;
using Arif.JWTAuthentication.Entities.Concrete;

namespace Arif.JWTAuthentication.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {

        }

        public Task<AppUser> FindByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
