using TodosWebAPI.Data;
using TodosWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodosWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService TodoService;

        public TodosController(ITodoService todoService)
        {
            TodoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Todo>>> GetTodos(int? userId)
        {
            try
            {
                IList<Todo> todos;
                if (userId is null)
                {
                    todos = await TodoService.GetTodosAsync();
                }
                else
                {
                    todos = await TodoService.GetTodosAsync((int) userId);
                }

                return Ok(todos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RemoveTodo([FromRoute] int id)
        {
            try
            {
                await TodoService.RemoveTodoAsync(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateTodo([FromBody] Todo todo)
        {
            try
            {
                await TodoService.UpdateTodoAsync(todo);
                return StatusCode(204);
            }
            catch (KeyNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddTodo([FromBody] Todo todo)
        {
            try
            {
                await TodoService.AddTodoAsync(todo);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}