using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly IRepository<TodoItem> repository;

        public TodoController(IRepository<TodoItem> repos)
        {
            repository = repos;
        }


        // GET: api/Todo
        [Authorize]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return repository.GetAll();
        }

        // GET: api/Todo/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST: api/Todo
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            repository.Add(item);

            return CreatedAtRoute("Get", new { id = item.Id }, item);
        }

        // PUT: api/Todo/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = repository.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            repository.Edit(todo);
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = repository.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            repository.Remove(id);
            return new NoContentResult();
        }
    }

}
