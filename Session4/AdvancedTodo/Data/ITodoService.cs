﻿using AdvancedTodo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedTodo.Data
{
    public interface ITodoService
    {
        Task<IList<Todo>> GetTodosAsync();
        Task AddTodoAsync(Todo todo);
        Task RemoveTodoAsync(int id);
        Task UpdateTodoAsync(Todo todo);
    }
}
