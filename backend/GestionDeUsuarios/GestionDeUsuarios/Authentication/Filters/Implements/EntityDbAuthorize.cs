using GestionDeUsuarios.Authentication.Filters.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionDeUsuarios.Authentication.Filters.Implements
{
    public class EntityDbAuthorize : IDbAuthorize
    {
        private DbContext db;
        public EntityDbAuthorize(DbContext dbContext)
        {
            db = dbContext;
        }

        public bool IsAuthorize(string controller, string action, string rol)
        {
            return false;
            //return (db.Set<Permissions>()
            //.Where(m => m.ControllerName == controller && m.Action == action && m.Roles.Name == rol).FirstOrDefault()) != null;
        }
    }
}
