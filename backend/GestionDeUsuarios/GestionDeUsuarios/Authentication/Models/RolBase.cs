using System.ComponentModel.DataAnnotations;

namespace GestionDeUsuarios.Authentication.Models
{
    public class RolBase
    {
        [Required]
        public string RolName { get; set; }
    }
}
