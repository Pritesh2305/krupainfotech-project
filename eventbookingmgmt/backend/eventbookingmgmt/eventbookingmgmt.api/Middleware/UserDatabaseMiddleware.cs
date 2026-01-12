using eventbookingmgmt.api.Helpers;

namespace eventbookingmgmt.api.Middleware
{
    public class UserDatabaseMiddleware(RequestDelegate next, ILogger<UserDatabaseMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext httpContext, IUserClientCodeService userClientCodeService)
        {
            var clientCode = httpContext.Request.Headers[Constants.ClientCodeHeaderName];
            userClientCodeService.ClientCode = clientCode;

            await next(httpContext);
        }
    }

    public static class UserDatabaseMiddleareRegistration
    {
        public static IApplicationBuilder UseUserDatabaseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserDatabaseMiddleware>();
        }
    }
}
