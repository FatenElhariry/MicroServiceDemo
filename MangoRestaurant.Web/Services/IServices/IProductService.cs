using MangoRestaurant.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRestaurant.Web.Services.IServices
{
    public interface IProductService
    {
        public Task<T> GetAllProductAsync<T>();
        public Task<T> GetProductByIdAsync<T>(long id);
        public Task<T> CreateProductAsync<T>(ProductDto product);
        public Task<T> UpdateProductAsync<T>(ProductDto product);
        public Task<T> DeleteProductAsync<T>(long id);
    }
}
