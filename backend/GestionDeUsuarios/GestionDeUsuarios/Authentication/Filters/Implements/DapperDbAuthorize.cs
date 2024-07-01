using GestionDeUsuarios.Authentication.Filters.Interfaces;

namespace GestionDeUsuarios.Authentication.Filters.Implements
{
    /// <summary>
    /// Using dapper micro orm for better performance
    /// </summary>
    public class DapperDbAuthorize : IDbAuthorize
    {
       
        private readonly string sql;
        public DapperDbAuthorize(string dbquey)
        {
           
            sql = dbquey;
        }

        public bool IsAuthorize(string controller, string action, string rol)
        {
            return true;
        }
    }
}
