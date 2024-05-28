using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactiontypecodesController : ControllerBase
    {
        private readonly AssetsContext _context;

        public FactiontypecodesController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/Factiontypecodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factiontypecode>>> GetFactiontypecodes()
        {
            return await _context.Factiontypecodes.ToListAsync();
        }

        // GET: api/Factiontypecodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factiontypecode>> GetFactiontypecode(int id)
        {
            var factiontypecode = await _context.Factiontypecodes.FindAsync(id);

            if (factiontypecode == null)
            {
                return NotFound();
            }

            return factiontypecode;
        }

        // POST: api/Factiontypecodes
        [HttpPost]
        public async Task<ActionResult<Factiontypecode>> PostFactiontypecode(Factiontypecode factiontypecode)
        {
            _context.Factiontypecodes.Add(factiontypecode);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFactiontypecode), new { id = factiontypecode.Id }, factiontypecode);
        }

        // PUT: api/Factiontypecodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactiontypecode(int id, Factiontypecode factiontypecode)
        {
            if (id != factiontypecode.Id)
            {
                return BadRequest();
            }

            _context.Entry(factiontypecode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactiontypecodeExists(id))
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

        // DELETE: api/Factiontypecodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactiontypecode(int id)
        {
            var factiontypecode = await _context.Factiontypecodes.FindAsync(id);
            if (factiontypecode == null)
            {
                return NotFound();
            }

            _context.Factiontypecodes.Remove(factiontypecode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactiontypecodeExists(int id)
        {
            return _context.Factiontypecodes.Any(e => e.Id == id);
        }
    }
}
