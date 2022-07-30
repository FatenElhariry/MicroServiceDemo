//using AutoMapper;
//using Mango.Services.ProductAPI.Data.Dtos;
//using Mango.Services.ProductAPI.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Mango.Services.ProductAPI.Data.AutoMapper
//{
//    public class MapperConfig
//    {
//        public static MapperConfiguration RegisterMaps()
//        {
//            return new MapperConfiguration(configure =>
//            {
//                configure.CreateMap<ProductDto,Product>().ForMember(dst => dst.Name, src => src.MapFrom(s => s.Name)).ReverseMap();
//                // configure.CreateMap
//            });

//        }

//    }
//}
