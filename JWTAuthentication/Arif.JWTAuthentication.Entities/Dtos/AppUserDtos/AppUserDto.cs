using System.Collections.Generic;

namespace Arif.JWTAuthentication.Entities.Dtos.AppUserDtos
{
    public class AppUserDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
    }
}
