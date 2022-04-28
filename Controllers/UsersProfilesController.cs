using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
using Phoenix.Models;

namespace Phoenix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersProfilesController : ControllerBase
    {
        private readonly PhoenixContext _context;

        public UsersProfilesController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersProfile>>> GetUsersProfile()
        {
            return await _context.UsersProfile.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsersProfile>> GetUsersProfile(int id)
        {
            var usersProfile = await _context.UsersProfile.FindAsync(id);

            if (usersProfile == null)
            {
                return NotFound();
            }

            return usersProfile;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersProfile(int id, UsersProfile usersProfile)
        {
            if (id != usersProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersProfileExists(id))
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
        public async Task<ActionResult<UsersProfile>> PostUsersProfile(UsersProfile usersProfile)
        {
            _context.UsersProfile.Add(usersProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersProfile", new { id = usersProfile.Id }, usersProfile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersProfile(int id)
        {
            var usersProfile = await _context.UsersProfile.FindAsync(id);
            if (usersProfile == null)
            {
                return NotFound();
            }

            _context.UsersProfile.Remove(usersProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersProfileExists(int id)
        {
            return _context.UsersProfile.Any(e => e.Id == id);
        }
    }
}
