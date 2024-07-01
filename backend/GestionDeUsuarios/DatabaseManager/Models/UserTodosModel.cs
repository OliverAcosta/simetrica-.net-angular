using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseManager.Entities
{
  
    public class UserTodosModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public bool isDone { get; set; } 

        public UserTodos ToEntity()
        {
            return new UserTodos
            {
                Id = this.Id,
                UserId = this.UserId,
                Task = this.Task,
                Description = this.Description,
                isDone =  (this.isDone) ? (byte)1 : (byte)0
            };
        }
    }
}
