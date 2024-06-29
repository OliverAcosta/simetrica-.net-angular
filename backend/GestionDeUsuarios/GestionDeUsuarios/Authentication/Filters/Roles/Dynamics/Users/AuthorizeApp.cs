using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using GestionDeUsuarios.Commons;
using GestionDeUsuarios.Authentication.Constants;
using Microsoft.AspNetCore.Authorization;

namespace GestionDeUsuarios.Authentication.Filters.Roles.Dynamics.Users
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class AuthorizeApp : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// EveryOneIsAuthorize used for let's access to every one
        /// </summary>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           
            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null )
            {
                return;
            }
            if (context.HttpContext.Items[AuthConsts.USERS] != null)
            {
                return;
            };

            context.Result = new JsonResult(RequestResult.Unauthorized) { StatusCode = StatusCodes.Status401Unauthorized };
            return;

        }
    }
}