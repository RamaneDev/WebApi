using Microsoft.AspNetCore.Builder;
using WebApi.MLW;

namespace WebApi.Extensions
{
    public static class Extensions
    {
        public static IApplicationBuilder UseTestMLW(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestMLW>();
        }

        public static IApplicationBuilder UseTestMLW2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestMLW2>();
        }

    }
}


