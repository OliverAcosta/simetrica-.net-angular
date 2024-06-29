
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseManager.Entities
{
    [Table("USERS")]
    public class Users
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("USERNAME")]
        public string Username { get; set; }
        [Column("FIRSTNAME")]
        public string Firstname { get; set; }
        [Column("LASTNAME")]
        public string Lastname { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("PASSWORD")]
        public string Password { get; set; }
        [Column("LASTLOGIN")]
        public DateTime LastLogin { get; set; }
    }
}
