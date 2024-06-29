using GestionDeUsuarios.Authentication.Constants;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeUsuarios.Controllers
{
    [Route("/api/[controller]")]
    [Controller]
    public class AppBaseController: ControllerBase
    {
        protected int GetUserId()
        {
            return -1;
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
