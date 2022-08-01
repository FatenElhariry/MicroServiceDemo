using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRestaurant.Web.Extensions
{
    public static class Extensions
    {

        public static string GetServiceUri(this StaticDetails details, string serviceName)
        {
            var type = details.GetType();
            var serviceProb = type.GetProperties().FirstOrDefault(x => x.Name.Equals($"{serviceName}ServiceUrl", StringComparison.OrdinalIgnoreCase));
            return serviceProb.GetValue(details).ToString();
        }

    }
}
