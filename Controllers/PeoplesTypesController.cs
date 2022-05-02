using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeoplesTypesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public PeoplesTypesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonType>>> GetDomPersonType()
        {
            return await _context.PersonType.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonType>> GetPersonType(string id)
        {
            var personType = await _context.PersonType.FindAsync(id);

            if (personType == null)
            {
                return NotFound();
            }

            return personType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonType(string id, PersonType personType)
        {
            if (id != personType.Id)
            {
                return BadRequest();
            }

            _context.Entry(personType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonTypeExists(id))
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

        [HttpPost]
        public async Task<ActionResult<PersonType>> PostPersonType(PersonType personType)
        {
            _context.PersonType.Add(personType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonTypeExists(personType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonType", new { id = personType.Id }, personType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonType(string id)
        {
            var personType = await _context.PersonType.FindAsync(id);
            if (personType == null)
            {
                return NotFound();
            }

            _context.PersonType.Remove(personType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonTypeExists(string id)
        {
            return _context.PersonType.Any(e => e.Id == id);
        }
    }

}
