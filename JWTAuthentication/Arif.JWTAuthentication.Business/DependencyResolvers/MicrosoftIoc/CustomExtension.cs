using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Business.Concrete;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Arif.JWTAuthentication.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Arif.JWTAuthentication.Business.DependencyResolvers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();
        }
    }
}
