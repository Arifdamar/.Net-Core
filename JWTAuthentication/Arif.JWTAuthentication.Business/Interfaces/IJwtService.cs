using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Entities.Concrete;

namespace Arif.JWTAuthentication.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(AppUser user, List<AppRole> roles);
    }
}
