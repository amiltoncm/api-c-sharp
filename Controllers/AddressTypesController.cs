using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public AddressTypesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressType>>> GetAddressType()
        {
            return await _context.AddressType.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressType>> GetAddressType(int id)
        {
            var addressType = await _context.AddressType.FindAsync(id);

            if (addressType == null)
            {
                return NotFound();
            }

            return addressType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressType(int id, AddressType addressType)
        {
            if (id != addressType.Id)
            {
                return BadRequest();
            }

            _context.Entry(addressType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressTypeExists(id))
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
        public async Task<ActionResult<AddressType>> PostAddressType(AddressType addressType)
        {
            _context.AddressType.Add(addressType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressType", new { id = addressType.Id }, addressType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressType(int id)
        {
            var addressType = await _context.AddressType.FindAsync(id);
            if (addressType == null)
            {
                return NotFound();
            }

            _context.AddressType.Remove(addressType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressTypeExists(int id)
        {
            return _context.AddressType.Any(e => e.Id == id);
        }
    }
}
