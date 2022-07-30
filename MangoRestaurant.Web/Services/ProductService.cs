using MangoRestaurant.Web.Models;
using MangoRestaurant.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRestaurant.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private StaticDetails _staticDetails;
        public ProductService(IHttpClientFactory clientFactory, StaticDetails staticDetails): base(clientFactory)
        {
            _staticDetails = staticDetails;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.Post,
                Data = product, 
                Url = _staticDetails.ProductServiceUrl + "/api/Product",
            });
        }

        public async Task<T> DeleteProductAsync<T>(long id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.Delete,
                Url = _staticDetails.ProductServiceUrl + $"/api/Product/{id}",
            });
        }

        public async Task<T> GetAllProductAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.Get,
                Url = _staticDetails.ProductServiceUrl + "/api/Product",
            });
        }

        public async Task<T> GetProductByIdAsync<T>(long id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.Get,
                Url = _staticDetails.ProductServiceUrl + $"/api/Product/{id}",
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.Put,
                Data = product,
                Url = _staticDetails.ProductServiceUrl + "/api/Product",
            });
        }
    }
}
