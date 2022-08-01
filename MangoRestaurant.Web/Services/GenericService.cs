using Mango.Kernal.DTOs;
using MangoRestaurant.Web.Extensions;
using MangoRestaurant.Web.Models;
using MangoRestaurant.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRestaurant.Web.Services
{
    public class GenericService<TDto> : IGenericService<TDto>
    {
        private readonly IBaseService _baseService;
        // public string EndpointName { get; set; }
        private readonly string _url;
        public GenericService(IBaseService baseService, StaticDetails staticDetails) 
        {
            string enpointName = this.GetType().GenericTypeArguments.First().Name.ToLower().Replace("dto", "");
            _baseService = baseService;
            _url = staticDetails.GetServiceUri(enpointName) + $"/api/{enpointName}";
        }
        public async Task<ResponseDto<TDto>> CreateAsync(TDto product)
        {
            return await _baseService.SendAsync<TDto>(new ApiRequest()
            {
                ApiType = ApiType.Post,
                Data = product,
                Url = _url,
            });
        }

        public async Task<ResponseDto<bool>> DeleteAsync(long id)
        {
            return await _baseService.SendAsync<bool>(new ApiRequest()
            {
                ApiType = ApiType.Delete,
                Url = $"{_url}/{id}",
            });
        }

        public async Task<ResponseDto<IList<TDto>>> GetAllAsync()
        {
            return await  _baseService.SendAsync<IList<TDto>>(new ApiRequest()
            {
                ApiType = ApiType.Get,
                Url = _url
            });
        }

        public async Task<ResponseDto<TDto>> GetByIdAsync(long id)
        {
            return await _baseService.SendAsync<TDto>(new ApiRequest()
            {
                ApiType = ApiType.Get,
                Url = $"{_url}/{id}",
            });
        }

        public async Task<ResponseDto<TDto>> UpdateAsync(TDto entity)
        {
            return await _baseService.SendAsync<TDto>(new ApiRequest()
            {
                ApiType = ApiType.Put,
                Data = entity,
                Url = _url,
            });
        }

       
    }
}
