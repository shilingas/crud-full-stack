using crudd_backend.Contexts;
using crudd_backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodosContext _context;

        public TodoController(TodosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("corsapp")]
        public async Task<TodoModel[]> GetAllTodos()
        {
            var data = await _context.Todos.ToArrayAsync();
            return data;
        }

        [HttpPost]
        [EnableCors("corsapp")]
        public async Task<IActionResult> PostTodo([FromBody] TodoModel model)
        {
            _context.Todos.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
        [HttpDelete("{id}")]
        [EnableCors("corsapp")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var currentTodo = await _context.Todos.FindAsync(id);
            if (currentTodo is not null)
            {
                _context.Todos.Remove(currentTodo);
                await _context.SaveChangesAsync();
                return Ok("removed");
            }
            return BadRequest("id was not found in db");
        }
        [HttpPut("{id}")]
        [EnableCors("corsapp")]
        public async Task<IActionResult> UpdateTodo([FromBody] TodoModel model, int id)
        {
            var currentTodo = await _context.Todos.FindAsync(id);
            if (currentTodo is not null)
            {
                currentTodo.Text = model.Text;
                currentTodo.Date = model.Date;
                await _context.SaveChangesAsync();
                return Ok("updated");
            }
            return BadRequest("id was not found in db");
        }
    }
}
