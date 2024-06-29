

namespace ScheduleApi.Filters.Roles.Atributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class SuperAdmin: Attribute, ISuperAdmin
    {
    }

    public interface ISuperAdmin
    {

    }
}
