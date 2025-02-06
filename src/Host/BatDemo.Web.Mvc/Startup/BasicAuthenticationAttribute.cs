using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BatDemo.Web.Startup
{
    /// <summary>
    /// Set basic authentication with BasicAuthenticationAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthenticationAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _username;
        private readonly string _password;

        /// <summary>
        /// BasicAuthenticationAttribute
        /// </summary>
        /// <param name="configuration"></param>
        public BasicAuthenticationAttribute(IOptions<BasicAuthSettings> authSettings)
        {
            _username = authSettings.Value.Username;
            _password = authSettings.Value.Password;
        }

        /// <summary>
        /// OnAuthorizationAsync
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.HttpContext.Request.Headers["Authorization"]);
                var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                if (!ValidateCredentials(username, password))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }

        /// <summary>
        /// ValidateCredentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ValidateCredentials(string username, string password)
        {
            // Replace this with actual validation (e.g., database check)
            return username == _username && password == _password;
        }
    }
}






