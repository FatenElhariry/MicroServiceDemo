using Mango.Kernal.DTOs;
using MangoRestaurant.Web.Models;
using MangoRestaurant.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRestaurant.Web.Controllers
{
    public class BaseServiceController<TDto>: Controller
    {
        private readonly IProductService _productService;
        public BaseServiceController(IProductService productService)
        {
            _productService = productService;
        }

        protected async Task<IList<TDto>> _getAll()
        {
            var response = await _productService.GetAllProductAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                return JsonConvert.DeserializeObject<List<TDto>>(JsonConvert.SerializeObject(response.Result));
            }
            return null;
        }

        protected async Task<TDto> _getById(long id)
        {
            var response = await _productService.GetProductByIdAsync<ResponseDto>(id);
            if (response != null && response.IsSuccess)
            {
                return JsonConvert.DeserializeObject<TDto>(JsonConvert.SerializeObject(response.Result));
            }
            return default(TDto);
        }

    }
}
