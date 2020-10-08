using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Entities.Dtos.AppUserDtos;
using FluentValidation;

namespace Arif.JWTAuthentication.Business.ValidationRules.FluentValidation
{
    public class AppUserRegisterDtoValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterDtoValidator()
        {
            RuleFor(I => I.FullName).NotEmpty().WithMessage("Ad ve Soyad Boş Geçilemez");
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");
        }
    }
}
