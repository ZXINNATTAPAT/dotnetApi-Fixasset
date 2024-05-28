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
    public class PropertySellersController : ControllerBase
    {
        private readonly AssetsContext _context;

        public PropertySellersController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/PropertySellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertySeller>>> GetPropertySellers()
        {
            return await _context.PropertySellers.ToListAsync();
        }

        // GET: api/PropertySellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertySeller>> GetPropertySeller(int id)
        {
            var propertySeller = await _context.PropertySellers.FindAsync(id);

            if (propertySeller == null)
            {
                return NotFound();
            }

            return propertySeller;
        }

        // POST: api/PropertySellers
        [HttpPost]
        public async Task<ActionResult<PropertySeller>> PostPropertySeller(PropertySeller propertySeller)
        {
            _context.PropertySellers.Add(propertySeller);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPropertySeller), new { id = propertySeller.Id }, propertySeller);
        }

        // PUT: api/PropertySellers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertySeller(int id, PropertySeller propertySeller)
        {
            if (id != propertySeller.Id)
            {
                return BadRequest();
            }

            _context.Entry(propertySeller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertySellerExists(id))
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

        // DELETE: api/PropertySellers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertySeller(int id)
        {
            var propertySeller = await _context.PropertySellers.FindAsync(id);
            if (propertySeller == null)
            {
                return NotFound();
            }

            _context.PropertySellers.Remove(propertySeller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertySellerExists(int id)
        {
            return _context.PropertySellers.Any(e => e.Id == id);
        }
    }
}
