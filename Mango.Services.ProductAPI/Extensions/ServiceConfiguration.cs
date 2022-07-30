using Mango.Services.ProductAPI.Infrastructure.Services;
using Mango.Services.ProductAPI.Persistence.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Extensions
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices (this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IService<,>), typeof(ServiceDecorator<,>));
            
        }
    }
}
