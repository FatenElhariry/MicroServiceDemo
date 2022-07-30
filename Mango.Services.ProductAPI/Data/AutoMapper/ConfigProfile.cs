using AutoMapper;
using Mango.Services.ProductAPI.Data.Dtos;
using Mango.Services.ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Data.AutoMapper
{
    public class ConfigProfile: Profile
    {
     
            public ConfigProfile()
            {
                ObjectToObject();
            }
            private void ObjectToObject()
            {
                CreateMap<ProductDto, Product>().ReverseMap();
            }

    }
}
