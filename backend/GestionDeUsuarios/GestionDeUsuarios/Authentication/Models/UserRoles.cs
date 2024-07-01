using System.ComponentModel.DataAnnotations;

namespace GestionDeUsuarios.Authentication.Models
{
    public class UserRoles
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }

    }
}
