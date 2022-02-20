using AutoMapper;
using ECommerce.Business.Models;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, SaveProductDTO>().ReverseMap();

            CreateMap<Category, SaveCategoryDTO>().ReverseMap();
        }
    }
}
