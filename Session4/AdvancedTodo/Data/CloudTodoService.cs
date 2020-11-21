using AdvancedTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdvancedTodo.Data
{
    public class CloudTodoService : ITodoService
    {
        private const string Uri = "http://localhost:5002/api/todos";

        public async Task AddTodoAsync(Todo todo)
        {
            HttpClient client = new HttpClient();
            await client.PostAsync(Uri, new StringContent(JsonSerializer.Serialize(todo), Encoding.UTF8, "application/json"));
        }

        public async Task<IList<Todo>> GetTodosAsync()
        {
            HttpClient client = new HttpClient();
            string msg = await client.GetStringAsync(Uri);
            List<Todo> result = JsonSerializer.Deserialize<List<Todo>>(msg);
            return result;
        }

        public async Task RemoveTodoAsync(int id)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync(Uri + $"/{id}");
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            HttpClient client = new HttpClient();
            var todoHttpContext = new StringContent(JsonSerializer.Serialize(todo), Encoding.UTF8, "application/json");
            await client.PatchAsync(Uri + $"/{todo.TodoID}", todoHttpContext);
        }
    }
}
