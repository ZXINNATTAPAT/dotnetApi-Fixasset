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
    public class ResponsiblePersonsController : ControllerBase
    {
        private readonly AssetsContext _context;

        public ResponsiblePersonsController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/ResponsiblePersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsibleperson>>> GetResponsiblePersons()
        {
            return await _context.ResponsiblePersons.ToListAsync();
        }

        // GET: api/ResponsiblePersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Responsibleperson>> GetResponsibleperson(int id)
        {
            var responsiblePerson = await _context.ResponsiblePersons.FindAsync(id);

            if (responsiblePerson == null)
            {
                return NotFound();
            }

            return responsiblePerson;
        }

        // POST: api/ResponsiblePersons
        [HttpPost]
        public async Task<ActionResult<Responsibleperson>> PostResponsibleperson(Responsibleperson responsiblePerson)
        {
            _context.ResponsiblePersons.Add(responsiblePerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResponsibleperson), new { id = responsiblePerson.Id }, responsiblePerson);
        }

        // PUT: api/ResponsiblePersons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponsibleperson(int id, Responsibleperson responsiblePerson)
        {
            if (id != responsiblePerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(responsiblePerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponsiblepersonExists(id))
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

        // DELETE: api/ResponsiblePersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsibleperson(int id)
        {
            var responsiblePerson = await _context.ResponsiblePersons.FindAsync(id);
            if (responsiblePerson == null)
            {
                return NotFound();
            }

            _context.ResponsiblePersons.Remove(responsiblePerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResponsiblepersonExists(int id)
        {
            return _context.ResponsiblePersons.Any(e => e.Id == id);
        }
    }
}
