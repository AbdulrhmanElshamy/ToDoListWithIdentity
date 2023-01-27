using ToDoListWithIdentity.Cores.Models;

namespace ToDoListWithIdentity.Services
{
    public interface IToDoService
    {
        Task<ToDo> GetByIdAsync(string userId,int id);

        Task<IEnumerable<ToDo>> GetAllAsync(string id);

        Task<bool> AddAsync(ToDo toDo);

        Task<bool> UpdateAsync(ToDo toDo);

        Task<bool> DeleteAsync(int? id);

        Task<List<ToDo>> NotCompletedTodoRemember();
    }
}
