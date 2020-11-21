using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodosWebAPI.Models;
using TodosWebAPI.Persistance;

namespace TodosWebAPI.Data
{
    public class SqliteTodoService : ITodoService
    {
        private readonly TodoContext _todoContext;

        public SqliteTodoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<IList<Todo>> GetTodosAsync()
        {
            return await _todoContext.Todos.ToListAsync();
        }

        public async Task<IList<Todo>> GetTodosAsync(int userId)
        {
            return await _todoContext.Todos.Where(t => t.UserID == userId).ToListAsync();
        }

        public async Task AddTodoAsync(Todo todo)
        {
            await _todoContext.Todos.AddAsync(todo);
            await _todoContext.SaveChangesAsync();
        }

        public async Task RemoveTodoAsync(int id)
        {
            var todo = await _todoContext.Todos.FindAsync(id);
            _todoContext.Remove(todo);
            await _todoContext.SaveChangesAsync();
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            var foundTodo = await _todoContext.Todos.FindAsync(todo.TodoID);
            foundTodo.Title = todo.Title;
            foundTodo.IsCompleted = todo.IsCompleted;
            foundTodo.UserID = todo.UserID;
            _todoContext.Update(foundTodo);
            await _todoContext.SaveChangesAsync();
        }
    }
}