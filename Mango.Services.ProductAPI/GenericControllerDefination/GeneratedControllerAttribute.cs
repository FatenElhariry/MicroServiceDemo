using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.GenericControllerDefination
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]

    public class GeneratedControllerAttribute: Attribute
    {
        public GeneratedControllerAttribute(string route)
        {
            Route = route;
        }

        public string Route { get; set; }
    }
}
