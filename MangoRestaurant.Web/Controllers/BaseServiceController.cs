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
        private readonly IGenericService<TDto> _service;
        public BaseServiceController(IGenericService<TDto> service)
        {
            _service = service;
        }

        protected async Task<IList<TDto>> _getAll()
        {
            var response = await _service.GetAllAsync();
            if (response != null && response.IsSuccess)
            {
                return response.Result;
            }
            return null;
        }

        protected async Task<TDto> _getById(long id)
        {
            var response = await _service.GetByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                return response.Result;
            }
            return default(TDto);
        }

        protected async Task<TDto> _create(TDto entity)
        {
            var response = await _service.CreateAsync(entity);
            if (response != null && response.IsSuccess)
            {
                return response.Result;
            }
            return default(TDto);
        }

    }
}
