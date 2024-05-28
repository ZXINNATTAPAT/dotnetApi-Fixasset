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
    public class AssetcategoriesController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetcategoriesController(AssetsContext context)
        {
            _context = context;
        }

        // POST: api/Assetcategories
        [HttpPost]
        public async Task<ActionResult<Assetcategory>> PostAssetcategory(Assetcategory assetcategory)
        {
            _context.Assetcategories.Add(assetcategory);
            await _context.SaveChangesAsync();

            // Invalidate cache for GetAssetDetails action
            Response.Headers["Cache-Control"] = "no-cache";

            return CreatedAtAction(nameof(GetAssetcategory), new { id = assetcategory.Id }, assetcategory);
        }

        // GET: api/Assetcategories
        [HttpGet]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Client)] 
        public async Task<ActionResult<IEnumerable<Assetcategory>>> GetAssetcategories()
        {
            return await _context.Assetcategories.ToListAsync();
        }

        // GET: api/Assetcategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assetcategory>> GetAssetcategory(int id)
        {
            var assetcategory = await _context.Assetcategories.FindAsync(id);

            if (assetcategory == null)
            {
                return NotFound();
            }

            return assetcategory;
        }

        // PUT: api/Assetcategories/5
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutAssetcategory(int id, Assetcategory assetcategory)
        {
            if (id != assetcategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(assetcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                // Invalidate cache for GetAssetDetails action
                Response.Headers["Cache-Control"] = "no-cache";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetcategoryExists(id))
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

        // DELETE: api/Assetcategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssetcategory(int id)
        {
            var assetcategory = await _context.Assetcategories.FindAsync(id);
            if (assetcategory == null)
            {
                return NotFound();
            }

            _context.Assetcategories.Remove(assetcategory);
            await _context.SaveChangesAsync();

            // Invalidate cache for GetAssetDetails action
            Response.Headers["Cache-Control"] = "no-cache";

            return NoContent();
        }

        private bool AssetcategoryExists(int id)
        {
            return _context.Assetcategories.Any(e => e.Id == id);
        }
    }
}
