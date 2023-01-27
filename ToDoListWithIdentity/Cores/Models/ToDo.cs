using System.ComponentModel.DataAnnotations;

namespace ToDoListWithIdentity.Cores.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [MaxLength(150),MinLength(5,ErrorMessage ="min lenght is 5 letter")]
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public bool InProgress { get; set; } = true;

        public bool IsCompleted { get; set; }

        public  string? ApplicationUserId { get; set; } = null!;
    }
}
