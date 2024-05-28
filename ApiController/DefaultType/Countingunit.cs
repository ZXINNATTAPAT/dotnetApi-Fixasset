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
    public class CountingunitsController : ControllerBase
    {
        private readonly AssetsContext _context;

        public CountingunitsController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/Countingunits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Countingunit>>> GetCountingunits()
        {
            return await _context.Countingunits.ToListAsync();
        }

        // GET: api/Countingunits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Countingunit>> GetCountingunit(int id)
        {
            var countingunit = await _context.Countingunits.FindAsync(id);

            if (countingunit == null)
            {
                return NotFound();
            }

            return countingunit;
        }

        // POST: api/Countingunits
        [HttpPost]
        public async Task<ActionResult<Countingunit>> PostCountingunit(Countingunit countingunit)
        {
            _context.Countingunits.Add(countingunit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountingunit), new { id = countingunit.Id }, countingunit);
        }

        // PUT: api/Countingunits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountingunit(int id, Countingunit countingunit)
        {
            if (id != countingunit.Id)
            {
                return BadRequest();
            }

            _context.Entry(countingunit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountingunitExists(id))
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

        // DELETE: api/Countingunits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountingunit(int id)
        {
            var countingunit = await _context.Countingunits.FindAsync(id);
            if (countingunit == null)
            {
                return NotFound();
            }

            _context.Countingunits.Remove(countingunit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountingunitExists(int id)
        {
            return _context.Countingunits.Any(e => e.Id == id);
        }
    }
}
