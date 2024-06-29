
using System.ComponentModel.DataAnnotations;

namespace GestionDeUsuarios.Authentication.Models
{
    public class TokenRefreshModel
    {
        [Required]
        public string Token { get; set; }
    }
}
