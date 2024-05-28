using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepreciationsController : ControllerBase
    {
        private readonly AssetsContext _context;

        public DepreciationsController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/Depreciations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depreciation>>> GetDepreciations()
        {
            return await _context.Depreciations.ToListAsync();
        }

        // GET: api/Depreciations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Depreciation>> GetDepreciation(int id)
        {
            var depreciation = await _context.Depreciations.FindAsync(id);

            if (depreciation == null)
            {
                return NotFound();
            }

            return depreciation;
        }

        // PUT: api/Depreciations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepreciation(int id, Depreciation depreciation)
        {
            if (id != depreciation.Id)
            {
                return BadRequest();
            }

            _context.Entry(depreciation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepreciationExists(id))
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

        // POST: api/Depreciations
        [HttpPost]
        public async Task<ActionResult<Depreciation>> PostDepreciation(Depreciation depreciation)
        {
            _context.Depreciations.Add(depreciation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepreciation", new { id = depreciation.Id }, depreciation);
        }

        // DELETE: api/Depreciations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepreciation(int id)
        {
            var depreciation = await _context.Depreciations.FindAsync(id);
            if (depreciation == null)
            {
                return NotFound();
            }

            _context.Depreciations.Remove(depreciation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepreciationExists(int id)
        {
            return _context.Depreciations.Any(e => e.Id == id);
        }
    }
}
