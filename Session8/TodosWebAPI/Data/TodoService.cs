using TodosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TodosWebAPI.Data
{
    public class TodoService : ITodoService
    {
        private readonly string _todoFile = "todos.json";
        private IList<Todo> _todos;

        public TodoService()
        {
            if (!File.Exists(_todoFile))
            {
                Seed();
                WriteTodosToFile();
            }
            else
            {
                string content = File.ReadAllText(_todoFile);
                _todos = JsonSerializer.Deserialize<IList<Todo>>(content);
            }
        }

        public Task<IList<Todo>> GetTodosAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task AddTodoAsync(Todo todo)
        {
            int max = _todos.Any() ? _todos.Max(todo => todo.TodoID) : 0;
            todo.TodoID = (++max);
            _todos.Add(todo);
            WriteTodosToFile();
        }

        public async Task RemoveTodoAsync(int id)
        {
            Todo toRemove = _todos.First(t => t.TodoID == id);
            _todos.Remove(toRemove);
            WriteTodosToFile();
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            Todo toUpdate = _todos.First(t => t.TodoID == todo.TodoID);
            if (toUpdate != null)
            {
                toUpdate.IsCompleted = todo.IsCompleted;
                WriteTodosToFile();
            }
            else
            {
                throw new KeyNotFoundException($"Todo with id: {todo.TodoID} not found");
            }
        }

        private void WriteTodosToFile()
        {
            string productAsJson = JsonSerializer.Serialize(_todos, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(_todoFile, productAsJson);
        }

        public async Task<IList<Todo>> GetTodosAsync()
        {
            return new List<Todo>(_todos);
        }
        private void Seed()
        {
            Todo[] ts =
            {
                new Todo
                {
                    UserID = 1,
                    TodoID = 1,
                    Title = "Do dishes",
                    IsCompleted = true
                },
                new Todo
                {
                    UserID = 2,
                    TodoID = 2,
                    Title = "Walk the dog",
                    IsCompleted = false
                },
                new Todo
                {
                    UserID = 3,
                    TodoID = 3,
                    Title = "Do DNP homework",
                    IsCompleted = true
                },
                new Todo
                {
                    UserID = 3,
                    TodoID = 4,
                    Title = "Eat breakfast",
                    IsCompleted = true
                },
                new Todo
                {
                    UserID = 4,
                    TodoID = 5,
                    Title = "Mow lawn",
                    IsCompleted = false
                }
            };
            _todos = ts.ToList();
        }
    }
}
