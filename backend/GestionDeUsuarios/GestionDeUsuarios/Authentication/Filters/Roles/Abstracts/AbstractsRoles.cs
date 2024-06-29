using GestionDeUsuarios.Authentication.Filters.Interfaces;

namespace GestionDeUsuarios.Authentication.Filters.Roles.Abstracts
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AbstractsRoles : Attribute
    {
        public static IDbAuthorize DbAuthorize { get; set; }
        public string Roles { get; set; }
    }
}
