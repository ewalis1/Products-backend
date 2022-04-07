using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Product.DataAccess.Models;
using Product.Domain.Models;

namespace Product.DataAccess
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Products, ProductsDto>().ReverseMap();
        }
    }
}
