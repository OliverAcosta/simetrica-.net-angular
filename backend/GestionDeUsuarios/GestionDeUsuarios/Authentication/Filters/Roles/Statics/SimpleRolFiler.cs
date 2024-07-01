using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using GestionDeUsuarios.Authentication.Filters.Roles.Abstracts;
using GestionDeUsuarios.Authentication.Constants;
using GestionDeUsuarios.Commons;

namespace GestionDeUsuarios.Authentication.Filters.Roles.Statics
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RolFilter : AbstractsRoles, IAuthorizationFilter
    {
        public RolFilter(string role) { Roles = role; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrWhiteSpace(Roles)) throw new Exception("Not in rol");
            string rs = (string)context.HttpContext.Items[AuthConsts.ROLES];
            if (rs != null)
            {
                if (Roles.Equals(rs, StringComparison.OrdinalIgnoreCase)) return;
            }
            context.Result = new JsonResult(new RequestResult { Message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }

}