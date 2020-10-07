using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Entities.Dtos.ProductDtos;
using FluentValidation;

namespace Arif.JWTAuthentication.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
        }
    }
}
