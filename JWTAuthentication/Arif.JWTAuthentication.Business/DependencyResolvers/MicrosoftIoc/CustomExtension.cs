using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Business.Concrete;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.Business.ValidationRules.FluentValidation;
using Arif.JWTAuthentication.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Arif.JWTAuthentication.DataAccess.Interfaces;
using Arif.JWTAuthentication.Entities.Dtos.AppUserDtos;
using Arif.JWTAuthentication.Entities.Dtos.ProductDtos;
using FluentValidation;
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

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
        }
    }
}
