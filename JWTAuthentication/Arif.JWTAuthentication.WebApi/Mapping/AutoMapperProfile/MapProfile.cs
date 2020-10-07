using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Entities.Concrete;
using Arif.JWTAuthentication.Entities.Dtos.ProductDtos;
using AutoMapper;

namespace Arif.JWTAuthentication.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
        }
    }
}
