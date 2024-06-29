using System.ComponentModel.DataAnnotations;

namespace GestionDeUsuarios.Authentication.Models
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
