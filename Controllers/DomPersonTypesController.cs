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
    public class DomPersonTypesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public DomPersonTypesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomPersonType>>> GetDomPersonType()
        {
            return await _context.DomPersonType.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DomPersonType>> GetDomPersonType(string id)
        {
            var domPersonType = await _context.DomPersonType.FindAsync(id);

            if (domPersonType == null)
            {
                return NotFound();
            }

            return domPersonType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomPersonType(string id, DomPersonType domPersonType)
        {
            if (id != domPersonType.Id)
            {
                return BadRequest();
            }

            _context.Entry(domPersonType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomPersonTypeExists(id))
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
        public async Task<ActionResult<DomPersonType>> PostDomPersonType(DomPersonType domPersonType)
        {
            _context.DomPersonType.Add(domPersonType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DomPersonTypeExists(domPersonType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDomPersonType", new { id = domPersonType.Id }, domPersonType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomPersonType(string id)
        {
            var domPersonType = await _context.DomPersonType.FindAsync(id);
            if (domPersonType == null)
            {
                return NotFound();
            }

            _context.DomPersonType.Remove(domPersonType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DomPersonTypeExists(string id)
        {
            return _context.DomPersonType.Any(e => e.Id == id);
        }
    }
}
