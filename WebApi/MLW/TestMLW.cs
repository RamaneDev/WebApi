using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApi.MLW
{
    public class TestMLW
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public TestMLW(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;

            _logger = logFactory.CreateLogger("TestMLW");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("TestMLW executing.. before");

            await _next(httpContext); // calling next middleware

            _logger.LogInformation("TestMLW executing.. after");

        }
    }

}



