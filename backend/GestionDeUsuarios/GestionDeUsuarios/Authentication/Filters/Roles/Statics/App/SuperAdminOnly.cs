
using GestionDeUsuarios.Authentication.Constants;
using GestionDeUsuarios.Authentication.Filters.Interfaces;
using GestionDeUsuarios.Authentication.Filters.Roles.Abstracts;
using GestionDeUsuarios.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestionDeUsuarios.Authentication.Filters.Roles.Statics.App
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class SuperAdminOnly : AbstractsRoles, IAuthorizationFilter, ISuperAdmin
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string rs = (string)context.HttpContext.Items[AuthConsts.ROLES];
            if (rs != null)
            {
                if (rs == UserConsts.SUPERADMIN) return;
            }
            context.Result = new JsonResult(RequestResult.Unauthorized) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
