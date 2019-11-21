using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Microservice.Middleware
{
    public class UserKeyValidatorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public UserKeyValidatorsMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            const string authenticationCookieName = "jwtToken";
            var cookie = context.Request.Cookies[authenticationCookieName];
            if (cookie != null)
            {
                //var token = JsonConvert.DeserializeObject<AccessToken>();
                context.Request.Headers.Append("Authorization", "Bearer " + cookie.ToString());
            }

            await _next.Invoke(context);

        }
    }

    #region ExtensionMethod
    public static class UserKeyValidatorsExtension
    {
        public static IApplicationBuilder ApplyUserKeyValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<UserKeyValidatorsMiddleware>();
            return app;
        }
    }
    #endregion
}
