using AdvancedTodo.Models;
using System.Collections.Generic;

namespace AdvancedTodo.Data
{
    public interface ITodoService
    {
        IList<Todo> GetTodos();
        void AddTodo(Todo todo);
    }
}
