namespace GestionDeUsuarios.Authentication.Filters.Interfaces
{
    public interface IDbAuthorize
    {
        public bool IsAuthorize(string controller, string action, string rol);
    }
}
