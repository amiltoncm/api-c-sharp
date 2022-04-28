using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomAddressesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public DomAddressesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomAddress>>> GetDomAddress()
        {
            return await _context.DomAddress.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DomAddress>> GetDomAddress(int id)
        {
            var domAddress = await _context.DomAddress.FindAsync(id);

            if (domAddress == null)
            {
                return NotFound();
            }

            return domAddress;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomAddress(int id, DomAddress domAddress)
        {
            if (id != domAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(domAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomAddressExists(id))
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
        public async Task<ActionResult<DomAddress>> PostDomAddress(DomAddress domAddress)
        {
            _context.DomAddress.Add(domAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDomAddress", new { id = domAddress.Id }, domAddress);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomAddress(int id)
        {
            var domAddress = await _context.DomAddress.FindAsync(id);
            if (domAddress == null)
            {
                return NotFound();
            }

            _context.DomAddress.Remove(domAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DomAddressExists(int id)
        {
            return _context.DomAddress.Any(e => e.Id == id);
        }
    }
}
