using System;
using System.Collections.Generic;
using System.Text;

namespace Arif.JWTAuthentication.Entities.Concrete
{
    public class AppRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
