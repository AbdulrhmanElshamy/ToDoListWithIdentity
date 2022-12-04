using Microsoft.AspNetCore.Identity;

namespace ToDoListWithIdentity.Cores.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public ICollection<ToDo> ToDoLists { get; set; } = new List<ToDo>();
    }
}
