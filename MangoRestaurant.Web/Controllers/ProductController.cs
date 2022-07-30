using Mango.Kernal.DTOs;
using MangoRestaurant.Web.Models;
using MangoRestaurant.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MangoRestaurant.Web.Controllers
{
    public class ProductController : BaseServiceController<ProductDto>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService): base(productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            return View(_getAll());
        }
    }
}
