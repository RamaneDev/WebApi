using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApi.MLW
{
    public class TestMLW2
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public TestMLW2(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;

            _logger = logFactory.CreateLogger("TestMLW2");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("TestMLW2 executing.. before");

            await _next(httpContext); // calling next middleware

            _logger.LogInformation("TestMLW2 executing.. after");

        }
    }
}

