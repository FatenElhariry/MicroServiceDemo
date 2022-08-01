//using Mango.Kernal.DTOs;
//using MangoRestaurant.Web.Models;
//using MangoRestaurant.Web.Services.IServices;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MangoRestaurant.Web.Services
//{
//    public class ProductService : BaseService, IProductService
//    {
//        private StaticDetails _staticDetails;
//        public ProductService(IHttpClientFactory clientFactory, StaticDetails staticDetails): base(clientFactory)
//        {
//            _staticDetails = staticDetails;
//        }
//        public async Task<ResponseDto> CreateProductAsync(ProductDto product)
//        {
//            return await this.SendAsync(new ApiRequest()
//            {
//                ApiType = ApiType.Post,
//                Data = product, 
//                Url = _staticDetails.ProductServiceUrl + "/api/Product",
//            });
//        }

//        public async Task<ResponseDto> DeleteProductAsync(long id)
//        {
//            return await this.SendAsync(new ApiRequest()
//            {
//                ApiType = ApiType.Delete,
//                Url = _staticDetails.ProductServiceUrl + $"/api/Product/{id}",
//            });
//        }

//        public async Task<ResponseDto> GetAllProductAsync()
//        {
//            return await this.SendAsync(new ApiRequest()
//            {
//                ApiType = ApiType.Get,
//                Url = _staticDetails.ProductServiceUrl + "/api/Product",
//            });
//        }

//        public async Task<ResponseDto> GetProductByIdAsync(long id)
//        {
//            return await this.SendAsync(new ApiRequest()
//            {
//                ApiType = ApiType.Get,
//                Url = _staticDetails.ProductServiceUrl + $"/api/Product/{id}",
//            });
//        }

//        public async Task<ResponseDto> UpdateProductAsync(ProductDto product)
//        {
//            return await this.SendAsync(new ApiRequest()
//            {
//                ApiType = ApiType.Put,
//                Data = product,
//                Url = _staticDetails.ProductServiceUrl + "/api/Product",
//            });
//        }
//    }
//}
