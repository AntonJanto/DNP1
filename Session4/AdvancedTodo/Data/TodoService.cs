using AdvancedTodo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdvancedTodo.Data
{
    public class TodoService : ITodoService
    {
        private string _todoFile = "todos.json";
        private IList<Todo> _todos;

        public TodoService()
        {
            if (!File.Exists(_todoFile))
            {
                Seed();
                string productAsJson = JsonSerializer.Serialize(_todos, new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(_todoFile, productAsJson);
            }
            else
            {
                string content = File.ReadAllText(_todoFile);
                _todos = JsonSerializer.Deserialize<IList<Todo>>(content);
            }
        }

        public void AddTodo(Todo todo)
        {
            int max = _todos.Max(todo => todo.TodoID);
            todo.TodoID = (++max);
            _todos.Add(todo);
            string productAsJson = JsonSerializer.Serialize(_todos);
            File.WriteAllText(_todoFile, productAsJson);
        }

        public IList<Todo> GetTodos()
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
