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
    public class DomPublicPlacesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public DomPublicPlacesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomPublicPlace>>> GetDomPublicPlace()
        {
            return await _context.DomPublicPlace.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DomPublicPlace>> GetDomPublicPlace(int id)
        {
            var domPublicPlace = await _context.DomPublicPlace.FindAsync(id);

            if (domPublicPlace == null)
            {
                return NotFound();
            }

            return domPublicPlace;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomPublicPlace(int id, DomPublicPlace domPublicPlace)
        {
            if (id != domPublicPlace.Id)
            {
                return BadRequest();
            }

            _context.Entry(domPublicPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomPublicPlaceExists(id))
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
        public async Task<ActionResult<DomPublicPlace>> PostDomPublicPlace(DomPublicPlace domPublicPlace)
        {
            _context.DomPublicPlace.Add(domPublicPlace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDomPublicPlace", new { id = domPublicPlace.Id }, domPublicPlace);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomPublicPlace(int id)
        {
            var domPublicPlace = await _context.DomPublicPlace.FindAsync(id);
            if (domPublicPlace == null)
            {
                return NotFound();
            }

            _context.DomPublicPlace.Remove(domPublicPlace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DomPublicPlaceExists(int id)
        {
            return _context.DomPublicPlace.Any(e => e.Id == id);
        }
    }
}
