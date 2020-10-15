using JWTAuthentication_Front.Builders.Abstract;
using JWTAuthentication_Front.Models;

namespace JWTAuthentication_Front.Builders.Concrete
{
    public class StatusBuilderDirector
    {
        private StatusBuilder builder;
        public StatusBuilderDirector(StatusBuilder builder)
        {
            this.builder = builder;
        }

        public Status GenerateStatus(AppUser activeUser, string roles)
        {
            return builder.GenerateStatus(activeUser, roles);
        }


    }
}