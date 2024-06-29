using GestionDeUsuarios.Authentication.Filters.Interfaces;

namespace GestionDeUsuarios.Authentication.Filters.Roles.Atributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class SuperAdmin : Attribute, ISuperAdmin
    {
    }
}
