using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRestaurant.Web
{
    public enum ApiType
    {
        Get,
        Post,
        Put,
        Delete,
    }
    public class StaticDetails
    {
        public static StaticDetails _instance;
        private StaticDetails()
        {

        }
        public string ProductServiceUrl { get; set; }

        public static StaticDetails PopulateStaticDetails(IConfiguration configuration)
        {
            if (_instance == null)
                _instance = configuration.GetSection("Services").Get<StaticDetails>();
            return _instance;
        }
    }
}
