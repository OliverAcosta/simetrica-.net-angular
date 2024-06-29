using System.ComponentModel.DataAnnotations;

namespace GestionDeUsuarios.Authentication.Models
{
    public class UserBase
    {
        [Required]
        public string Username { get; set; }
    }
}
