using Microsoft.AspNetCore.Mvc;
using TodoList.WebApi.Models;
using TodoList.WebApi.Repositories;

namespace TodoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository _repository;

        public TodoController(TodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var todos = _repository.GetAll();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var todo = _repository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoItem todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest();
            }

            _repository.Add(todoItem);
            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TodoItem todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest();
            }

            _repository.Update(todoItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var todoItem = _repository.GetById(id);
            if(todoItem == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}
