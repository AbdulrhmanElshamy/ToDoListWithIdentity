using System.ComponentModel.DataAnnotations;

namespace ToDoListWithIdentity.Cores.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public bool InProgress { get; set; }

        public bool IsCompleted { get; set; }

        public virtual string ApplicationUserId { get; set; } = null!;
    }
}
