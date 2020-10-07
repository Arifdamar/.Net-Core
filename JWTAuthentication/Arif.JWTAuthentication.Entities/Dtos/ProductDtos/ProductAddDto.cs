using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Entities.Interfaces;

namespace Arif.JWTAuthentication.Entities.Dtos.ProductDtos
{
    public class ProductAddDto : IDto
    {
        public string Name { get; set; }
    }
}
