using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Controllers;

namespace Mango.Services.ProductAPI.GenericControllerDefination
{
    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        ILogger<GenericTypeControllerFeatureProvider> _logger;
        public GenericTypeControllerFeatureProvider(ILogger<GenericTypeControllerFeatureProvider> logger)
        {
            _logger = logger;
            _logger.LogInformation("Controller discovery feature provider invoked");
        }
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(GenericTypeControllerFeatureProvider).Assembly;
            _logger.LogInformation($"Controller discovery current assembly {currentAssembly.FullName}");
            var candidates = currentAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

            foreach (var candidate in candidates)
            {
                feature.Controllers.Add(typeof(BaseController<,>).MakeGenericType(candidate).GetTypeInfo());
            }
        }
    }
}
