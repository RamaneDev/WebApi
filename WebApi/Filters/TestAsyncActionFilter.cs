using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebApi.Filters
{
    public class TestAsyncActionFilter : IAsyncActionFilter
    {
        private readonly ILogger _logger;

        public TestAsyncActionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TestAsyncActionFilter");
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            
            _logger.LogInformation(string.Format("TestAsyncActionFilter executing.. before : {0}", actionName));

            await next();

            _logger.LogInformation(string.Format("TestAsyncActionFilter executing.. after : {0}", actionName));

        }
    }
}
