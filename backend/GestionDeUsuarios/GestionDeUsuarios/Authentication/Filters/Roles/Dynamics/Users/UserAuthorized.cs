
//using Commons.Webapi.Authentication.Constants;
//using Commons.Webapi.Authentication.Filters.Roles.Abstracts;
//using Commons.Webapi.Models.RequestMessages;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Controllers;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace Commons.Webapi.Authentication.Filters.Roles.Dynamics.Users
//{
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
//    internal class UserAuthorized : AbstractsRoles, IAuthorizationFilter
//    {
//        public static bool SuperAdminFullAccess { get; set; } = true;
//        public static bool NotCheckForRoles { get; set; } = false;
//        public bool CheckForRol { get; set; } = true;
//        public static bool EveryOneIsAuthorize { get; set; }
//        public void OnAuthorization(AuthorizationFilterContext context)
//        {
//            //uncoment in production
//            var endpoint = context.HttpContext.GetEndpoint();
//            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null || EveryOneIsAuthorize)
//            {
//                return;
//            }
//            if (context.HttpContext.Items[AuthConsts.USERS] == null)
//            {
//                context.Result = new JsonResult(RequestResult.Unauthorized) { StatusCode = StatusCodes.Status401Unauthorized };
//                return;
//            };
//            //uncoment in production
//            //if (endpoint?.Metadata?.GetMetadata<SuperAdmin>() != null)
//            //{
//            //    if((string)context.HttpContext.Items[AuthConsts.ROLES]?.ToString() == UserConsts.SUPERADMIN)
//            //        return;
//            //}    

//            if (!CheckForRol || NotCheckForRoles) return;

//            string rs = (string)context.HttpContext.Items[AuthConsts.ROLES];
//            if (rs != null)
//            {
//                if (SuperAdminFullAccess && rs == UserConsts.SUPERADMIN) return;
//                if (DbAuthorize is null) throw new NullReferenceException($"{nameof(DbAuthorize)} cannot be null");
//                if (context.ActionDescriptor is ControllerActionDescriptor cad &&
//                    DbAuthorize.IsAuthorize(cad.ControllerName, cad.ActionName, rs))
//                {
//                    return;
//                }
//            }
//            // not logged in
//            context.Result = new JsonResult(RequestResult.Unauthorized) { StatusCode = StatusCodes.Status401Unauthorized };

//        }
//    }
//}
