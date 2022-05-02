using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicPlacesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public PublicPlacesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicPlace>>> GetDomPublicPlace()
        {
            return await _context.PublicPlace.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublicPlace>> GetPublicPlace(int id)
        {
            var publicPlace = await _context.PublicPlace.FindAsync(id);

            if (publicPlace == null)
            {
                return NotFound();
            }

            return publicPlace;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicPlace(int id, PublicPlace publicPlace)
        {
            if (id != publicPlace.Id)
            {
                return BadRequest();
            }

            _context.Entry(publicPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicPlaceExists(id))
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
        public async Task<ActionResult<PublicPlace>> PostPublicPlace(PublicPlace publicPlace)
        {
            _context.PublicPlace.Add(publicPlace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicPlace", new { id = publicPlace.Id }, publicPlace);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicPlace(int id)
        {
            var publicPlace = await _context.PublicPlace.FindAsync(id);
            if (publicPlace == null)
            {
                return NotFound();
            }

            _context.PublicPlace.Remove(publicPlace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicPlaceExists(int id)
        {
            return _context.PublicPlace.Any(e => e.Id == id);
        }
    }
}
