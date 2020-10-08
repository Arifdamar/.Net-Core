using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Entities.Dtos.AppUserDtos;
using FluentValidation;

namespace Arif.JWTAuthentication.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");
        }
    }
}
