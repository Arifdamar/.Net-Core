using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
