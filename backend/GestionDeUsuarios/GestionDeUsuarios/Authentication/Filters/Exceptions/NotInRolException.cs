

namespace GestionDeUsuarios.Authentication.Filters.Exceptions
{
    public class NotInRolException: Exception
    {
        public static string NotInRol = "This user needs to be in a role.";

        public NotInRolException(string message):base(message)
        {

        }
        public NotInRolException():base(NotInRol)
        {
            
        }
    }
}