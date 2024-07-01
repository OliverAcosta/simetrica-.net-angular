using GestionDeUsuarios.Authentication.Constants;
using GestionDeUsuarios.Authentication.Filters.Exceptions;
using GestionDeUsuarios.Authentication.Filters.Roles.Abstracts;
using GestionDeUsuarios.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestionDeUsuarios.Authentication.Filters.Roles.Statics.Multiples
{
    /// <summary>
    /// This class implement check for multiples roles
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class MultipleRolesFilter : AbstractsRoles, IAuthorizationFilter
    {
        public MultipleRolesFilter(string role) { Roles = role; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrWhiteSpace(Roles)) throw new NotInRolException();
            string rs = context.HttpContext.Items[AuthConsts.ROLES]?.ToString();
            if (rs != null)
            {
                string[] roles = Roles.Split(',');
                for (int i = 0; i < roles.Length; i++)
                {
                    if (rs.Contains(roles[i])) return;
                }
            }
            context.Result = new JsonResult(RequestResult.Unauthorized) { StatusCode = StatusCodes.Status401Unauthorized };
        }

    }
}