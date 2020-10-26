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
        private readonly string URI = "https://jsonplaceholder.typicode.com/todos";
        public async Task AddTodoAsync(Todo todo)
        {
            HttpClient client = new HttpClient();
            await client.PostAsync(URI, new StringContent(JsonSerializer.Serialize(todo), Encoding.UTF8, "application/json"));
        }

        public async Task<IList<Todo>> GetTodosAsync()
        {
            HttpClient client = new HttpClient();
            string msg = await client.GetStringAsync(URI);
            List<Todo> result = JsonSerializer.Deserialize<List<Todo>>(msg);
            return result;
        }

        public async Task RemoveTodoAsync(Todo todo)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync(URI + $"?TodoId={todo.TodoID}");
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            var todoHttpContext = new StringContent(JsonSerializer.Serialize(todo.TodoID), Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            await client.PatchAsync(URI + $"?TodoId={todo.TodoID}", todoHttpContext);
        }
    }
}
