using System.Threading.Tasks;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    public class ControllerCrudBase<T, R> : ControllerBase
    where T : EntityBase
    where R : Repository<T>
    {
        protected R repository;

        public ControllerCrudBase(R r)
        {
            repository = r;
        }

        // GET: api/T
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await repository.ListAll());
        }

        // GET: api/T/2
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetById(id));
        }

        // PUT: api/T/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != entity.Id)
            {
                return BadRequest();
            }

            T e = await repository.Update(entity);
            if (e == null)
            {
                return NotFound();
            }

            return Ok(e);
        }

        // POST: api/T
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            T e = await repository.Add(entity);
            if (e == null)
            {
                return NotFound();
            }

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/T/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
    }
}