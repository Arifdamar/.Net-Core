using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.DataAccess.Interfaces;
using Arif.JWTAuthentication.Entities.Concrete;

namespace Arif.JWTAuthentication.Business.Concrete
{
    public class AppUserRoleManager : GenericManager<AppUserRole>, IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal) : base(genericDal)
        {

        }
    }
}
