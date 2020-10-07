using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Entities.Dtos.ProductDtos;
using FluentValidation;

namespace Arif.JWTAuthentication.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue);
            RuleFor(I => I.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
        }
    }
}
