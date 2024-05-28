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
    public class AssettypecodesController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssettypecodesController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/Assettypecodes
        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Client)] 
        public async Task<ActionResult<IEnumerable<Assettypecode>>> GetAssettypecodes()
        {
            // Get the asset type codes from the database
            var assetTypeCodes = await _context.Assettypecodes.ToListAsync();
            
            // Set Cache-Control header to cache the response for 10 minutes (600 seconds)
            // Response.Headers["Cache-Control"] = "public, max-age=600";
            
            // Return the asset type codes
            return assetTypeCodes;
        }

        // GET: api/Assettypecodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assettypecode>> GetAssettypecode(int id)
        {
            var assettypecode = await _context.Assettypecodes.FindAsync(id);

            if (assettypecode == null)
            {
                return NotFound();
            }

            return assettypecode;
        }

        // POST: api/Assettypecodes
        [HttpPost]
        public async Task<ActionResult<Assettypecode>> PostAssettypecode(Assettypecode assettypecode)
        {
            _context.Assettypecodes.Add(assettypecode);
            await _context.SaveChangesAsync();

            // Invalidate cache for GetAssetDetails action
            Response.Headers["Cache-Control"] = "no-cache";

            return CreatedAtAction(nameof(GetAssettypecode), new { id = assettypecode.Id }, assettypecode);
        }

        // PUT: api/Assettypecodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssettypecode(int id, Assettypecode assettypecode)
        {
            if (id != assettypecode.Id)
            {
                return BadRequest();
            }

            _context.Entry(assettypecode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Invalidate cache for GetAssetDetails action
                Response.Headers["Cache-Control"] = "no-cache";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssettypecodeExists(id))
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

        // DELETE: api/Assettypecodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssettypecode(int id)
        {
            var assettypecode = await _context.Assettypecodes.FindAsync(id);
            if (assettypecode == null)
            {
                return NotFound();
            }

            _context.Assettypecodes.Remove(assettypecode);
            await _context.SaveChangesAsync();

            // Invalidate cache for GetAssetDetails action
            Response.Headers["Cache-Control"] = "no-cache";

            return NoContent();
        }

        private bool AssettypecodeExists(int id)
        {
            return _context.Assettypecodes.Any(e => e.Id == id);
        }
    }
}
