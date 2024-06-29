using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseManager.Entities
{
    [Table("USERTODOS")]
    public class UserTodos
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("USERID")]
        public int UserId { get; set; }
        [Column("TASK")]
        public string Task { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("ISDONE")]
        public bool IsDone { get; set; }
    }
}
