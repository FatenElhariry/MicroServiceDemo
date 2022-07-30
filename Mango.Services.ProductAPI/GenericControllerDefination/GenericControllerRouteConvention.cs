//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Mvc.ApplicationModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace Mango.Services.ProductAPI.GenericControllerDefination
//{
//    public class GenericControllerRouteConvention : IControllerModelConvention
//    {
//        public void Apply(ControllerModel controller)
//        {
//            if (controller.ControllerType.IsGenericType)
//            {
//                var genericType = controller.ControllerType.GenericTypeArguments[0];
//                var customNameAttribute = genericType.GetCustomAttribute<GeneratedControllerAttribute>();

//                if (customNameAttribute?.Route != null)
//                {
//                    controller.Selectors.Add(new SelectorModel
//                    {
//                        AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route)),
//                    });
//                }
//            }
//        }
//    }
//}
