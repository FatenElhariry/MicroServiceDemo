using Mango.Kernal.DTOs;
using MangoRestaurant.Web.Models;
using MangoRestaurant.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MangoRestaurant.Web.Controllers
{
    public class ProductController : BaseServiceController<ProductDto>
    {

        public ProductController(IGenericService<ProductDto> productService, ILogger<ProductController> logger) : base(productService)
        { 
        }

        public async Task<IActionResult> Index()
        {
            return View(await _getAll());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductDto product)
        {
            if (!ModelState.IsValid)
                return View(product);
            var response = _create(product);
            //if (response.)
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var response = await _getById(id);

            return View(response);
        }
    }
}
