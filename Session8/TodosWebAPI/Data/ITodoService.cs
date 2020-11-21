using TodosWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodosWebAPI.Data
{
    public interface ITodoService
    {
        Task<IList<Todo>> GetTodosAsync();
        Task<IList<Todo>> GetTodosAsync(int userId);
        Task AddTodoAsync(Todo todo);
        Task RemoveTodoAsync(int id);
        Task UpdateTodoAsync(Todo todo);
    }
}
