using JWTAuthentication_Front.Builders.Concrete;
using JWTAuthentication_Front.Models;

namespace JWTAuthentication_Front.Builders.Abstract
{
    public abstract class StatusBuilder
    {
        public abstract Status GenerateStatus(AppUser activeUser, string roles);
    }
}