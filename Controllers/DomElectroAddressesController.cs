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
    public class DomElectroAddressesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public DomElectroAddressesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomElectroAddress>>> GetDomElectroAddress()
        {
            return await _context.DomElectroAddress.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DomElectroAddress>> GetDomElectroAddress(int id)
        {
            var domElectroAddress = await _context.DomElectroAddress.FindAsync(id);

            if (domElectroAddress == null)
            {
                return NotFound();
            }

            return domElectroAddress;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomElectroAddress(int id, DomElectroAddress domElectroAddress)
        {
            if (id != domElectroAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(domElectroAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomElectroAddressExists(id))
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
        public async Task<ActionResult<DomElectroAddress>> PostDomElectroAddress(DomElectroAddress domElectroAddress)
        {
            _context.DomElectroAddress.Add(domElectroAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDomElectroAddress", new { id = domElectroAddress.Id }, domElectroAddress);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomElectroAddress(int id)
        {
            var domElectroAddress = await _context.DomElectroAddress.FindAsync(id);
            if (domElectroAddress == null)
            {
                return NotFound();
            }

            _context.DomElectroAddress.Remove(domElectroAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DomElectroAddressExists(int id)
        {
            return _context.DomElectroAddress.Any(e => e.Id == id);
        }
    }
}
