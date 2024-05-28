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
    public class SectiontypecodesController : ControllerBase
    {
        private readonly AssetsContext _context;

        public SectiontypecodesController(AssetsContext context)
        {
            _context = context;
        }

        // POST: api/Sectiontypecodes
        [HttpPost]
        public async Task<ActionResult<Sectiontypecode>> PostSectiontypecode(Sectiontypecode sectiontypecode)
        {
            _context.SectionTypeCodes.Add(sectiontypecode);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSectiontypecode), new { id = sectiontypecode.SectionId }, sectiontypecode);
        }

        // GET: api/Sectiontypecodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sectiontypecode>>> GetSectiontypecodes()
        {
            return await _context.SectionTypeCodes.ToListAsync();
        }

        // GET: api/Sectiontypecodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sectiontypecode>> GetSectiontypecode(int id)
        {
            var sectiontypecode = await _context.SectionTypeCodes.FindAsync(id);

            if (sectiontypecode == null)
            {
                return NotFound();
            }

            return sectiontypecode;
        }

        // PUT: api/Sectiontypecodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSectiontypecode(int id, Sectiontypecode sectiontypecode)
        {
            if (id != sectiontypecode.SectionId)
            {
                return BadRequest();
            }

            _context.Entry(sectiontypecode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectiontypecodeExists(id))
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

        // DELETE: api/Sectiontypecodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSectiontypecode(int id)
        {
            var sectiontypecode = await _context.SectionTypeCodes.FindAsync(id);
            if (sectiontypecode == null)
            {
                return NotFound();
            }

            _context.SectionTypeCodes.Remove(sectiontypecode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectiontypecodeExists(int id)
        {
            return _context.SectionTypeCodes.Any(e => e.SectionId == id);
        }
    }
}
