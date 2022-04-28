using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectroAddressTypesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public ElectroAddressTypesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectroAddressType>>> GetDomElectroAddress()
        {
            return await _context.DomElectroAddress.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElectroAddressType>> GetElectroAddressType(int id)
        {
            var electroAddressType = await _context.DomElectroAddress.FindAsync(id);

            if (electroAddressType == null)
            {
                return NotFound();
            }

            return electroAddressType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectroAddressType(int id, ElectroAddressType electroAddressType)
        {
            if (id != electroAddressType.Id)
            {
                return BadRequest();
            }

            _context.Entry(electroAddressType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectroAddressTypeExists(id))
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
        public async Task<ActionResult<ElectroAddressType>> PostElectroAddressType(ElectroAddressType electroAddressType)
        {
            _context.DomElectroAddress.Add(electroAddressType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectroAddressType", new { id = electroAddressType.Id }, electroAddressType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElectroAddressType(int id)
        {
            var electroAddressType = await _context.DomElectroAddress.FindAsync(id);
            if (electroAddressType == null)
            {
                return NotFound();
            }

            _context.DomElectroAddress.Remove(electroAddressType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElectroAddressTypeExists(int id)
        {
            return _context.DomElectroAddress.Any(e => e.Id == id);
        }
    }
}
