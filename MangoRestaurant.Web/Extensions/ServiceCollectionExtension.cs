using MangoRestaurant.Web.Services;
using MangoRestaurant.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRestaurant.Web.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static void Register(this IServiceCollection services, ConfigurationManager configuration)
        {
            // services.BuildServiceProvider().GetService<IConfiguration>()
            services.AddSingleton(x => StaticDetails.PopulateStaticDetails(configuration));
            services.AddHttpClient<IProductService, ProductService>();
            services.AddTransient<IProductService, ProductService>();
            
        }

    }
}
