using DatabaseManager.Auth.Models;
using GestionDeUsuarios.Authentication.Constants;
using GestionDeUsuarios.Authentication.Filters.Roles.Dynamics.Users;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeUsuarios.Controllers
{
    [AuthorizeApp]
    [Route("api/[controller]")]
    [ApiController]
    public class AppBaseController: ControllerBase
    {
        protected int GetUserId()
        {
            try
            {
                return Convert.ToInt32(((AppUser)this.HttpContext.Items[AuthConsts.USERS])?.Id);
            }catch(Exception)
            {
                return -1;
            }
        }
        protected DateTime GetUserDatetimeFromOffset()
        {
            try
            {
                string gmtOffsets = Convert.ToString(HttpContext.Request.Headers[AuthConsts.OFFSET]);
                return DateTime.UtcNow.AddHours(Convert.ToInt32(gmtOffsets));
            }
            catch (Exception)
            {
                return DateTime.UtcNow;
            }
        }
    }
}
