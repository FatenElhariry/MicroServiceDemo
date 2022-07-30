using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MangoRestaurant.Web.StaticDetails;

namespace MangoRestaurant.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.Get;
        public string Url { get; set; }
        public Object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
