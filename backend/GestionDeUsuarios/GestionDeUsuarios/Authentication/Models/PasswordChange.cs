
using System.ComponentModel.DataAnnotations;
namespace GestionDeUsuarios.Authentication.Models
{
    public class PasswordChange: UserModel
    {

        [Required]
        public string NewPassword { get; set; }
    }
}
