using Mango.Services.ProductAPI.Data.Dtos;
using Mango.Services.ProductAPI.Infrastructure.Services;
using Mango.Services.ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Controllers
{
    public class ProductController : BaseController<ProductDto, Product>
    {
        public ProductController(IService<ProductDto, Product> service) : base(service)
        {
        }
    }
}
