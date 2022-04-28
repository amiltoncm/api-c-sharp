using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegimesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public RegimesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Regime>>> GetRegime()
        {
            return await _context.Regime.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Regime>> GetRegime(int id)
        {
            var regime = await _context.Regime.FindAsync(id);

            if (regime == null)
            {
                return NotFound();
            }

            return regime;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegime(int id, Regime regime)
        {
            if (id != regime.Id)
            {
                return BadRequest();
            }

            _context.Entry(regime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegimeExists(id))
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
        public async Task<ActionResult<Regime>> PostRegime(Regime regime)
        {
            _context.Regime.Add(regime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegime", new { id = regime.Id }, regime);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegime(int id)
        {
            var regime = await _context.Regime.FindAsync(id);
            if (regime == null)
            {
                return NotFound();
            }

            _context.Regime.Remove(regime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegimeExists(int id)
        {
            return _context.Regime.Any(e => e.Id == id);
        }
    }
}
