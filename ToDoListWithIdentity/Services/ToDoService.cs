using Microsoft.EntityFrameworkCore;
using ToDoListWithIdentity.Cores.Models;
using ToDoListWithIdentity.Data;

namespace ToDoListWithIdentity.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationDbContext _context;

        public ToDoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDo> GetByIdAsync(string userId ,int id)
        {

            return await _context.ToDoList.AsNoTracking().FirstOrDefaultAsync(e => e.ApplicationUserId == userId && e.Id == id);
        }


        public async Task<IEnumerable<ToDo>> GetAllAsync(string id)
        
        {
            return await _context.ToDoList.AsNoTracking().Where(e => e.ApplicationUserId == id).ToListAsync();
        }

        public async Task<bool> AddAsync(ToDo toDo)
        {
            try
            {

                await _context.AddAsync(toDo);
                await _context.SaveChangesAsync();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> UpdateAsync(ToDo toDo)
        {
            try
            {
                _context.Update(toDo);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            try
            {
                var todo = _context.ToDoList?.FindAsync(id);

                if (todo is  null)
                    return false;

                _context.Remove(todo);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ToDo>> NotCompletedTodoRemember()
        {
            return await _context.ToDoList.Where(e => e.IsCompleted == false).ToListAsync();
        }

    }
}
