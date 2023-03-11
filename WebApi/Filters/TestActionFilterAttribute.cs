using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Diagnostics;
using Microsoft.AspNetCore.Routing;

namespace WebApi.Filters
{
    public class TestActionFilterAttribute : ActionFilterAttribute
    {       

        public override async Task OnActionExecutionAsync(ActionExecutingContext context,  ActionExecutionDelegate next)
        {
            var message = getMessageLog("FilterAttribute -> OnActionExecutionAsync -> before", context.RouteData);

            Debug.WriteLine(message);

            await next();

            message = getMessageLog("FilterAttribute -> OnActionExecutionAsync -> after", context.RouteData);

            Debug.WriteLine(message);
        }
     

        /// <inheritdoc />
        public override async Task OnResultExecutionAsync(ResultExecutingContext context,  ResultExecutionDelegate next)
        {
            var message = getMessageLog("FilterAttribute -> OnResultExecutionAsync -> before", context.RouteData);

            Debug.WriteLine(message);

            await next();

            message = getMessageLog("FilterAttribute -> OnResultExecutionAsync -> after", context.RouteData);

            Debug.WriteLine(message);
        }


        private string getMessageLog(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            return String.Format("{0}- controller:{1} action:{2}", methodName,
                                                                        controllerName,
                                                                        actionName);
          
        }
    }
}
