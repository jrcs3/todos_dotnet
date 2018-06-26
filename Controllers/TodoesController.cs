using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todos_dotnet.Models;

namespace Todos_dotnet.Controllers
{
    [Produces("application/json")]
    [Route("api/Todoes")]
    public class TodoesController : Controller
    {
        private readonly Todos_dotnetContext _context;

		private static readonly Expression<Func<Todo, TodoDto>> AsTodoDto =
			x => new TodoDto
			{
				TodoId = x.TodoId,
				Title = x.Title,
				Due = x.Due,
				PersonId = x.PersonId,
				PersonName = x.Person.Name,
				Done = x.Done
			};


		public TodoesController(Todos_dotnetContext context)
        {
            _context = context;
        }

        // GET: api/Todoes
        [HttpGet]
        public IEnumerable<TodoDto> GetTodo()
		{
			//return _context.Todo.Include(x => x.Person);
			return _context.Todo.Include(x => x.Person).Select(AsTodoDto);
			//return _context.Todo;
		}

        // GET: api/Todoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			//var todo = await _context.Todo.Include(x => x.Person).SingleOrDefaultAsync(m => m.TodoId == id);
			//var todo = await _context.Todo.SingleOrDefaultAsync(m => m.TodoId == id);
			var todo = await _context.Todo.Include(x => x.Person).Where(x => x.TodoId == id).Select(AsTodoDto).FirstOrDefaultAsync();

			if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // PUT: api/Todoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo([FromRoute] int id, [FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todo.TodoId)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todoes
        [HttpPost]
        public async Task<IActionResult> PostTodo([FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Todo.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.TodoId }, todo);
        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = await _context.Todo.SingleOrDefaultAsync(m => m.TodoId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.TodoId == id);
        }
    }
}