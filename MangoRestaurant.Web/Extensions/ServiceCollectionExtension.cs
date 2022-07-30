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

        public static void Register(this IServiceCollection services)
        {
            // services.BuildServiceProvider().GetService<IConfiguration>()
            services.AddSingleton<StaticDetails>(x => StaticDetails.PopulateStaticDetails(x.GetService<IConfiguration>()));
            services.AddScoped<IProductService, ProductService>();
            services.AddHttpClient<IProductService, ProductService>();
        }

    }
}
