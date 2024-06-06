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
    public class AssetDetailsAuditController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetDetailsAuditController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/AssetDetailsAudit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetDetailsAudit>>> GetAssetDetailsAudits()
        {
            return await _context.AssetDetailsAudits.ToListAsync();
        }

        // GET: api/AssetDetailsAudit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDetailsAudit>> GetAssetDetailsAudit(int id)
        {
            var assetDetailsAudit = await _context.AssetDetailsAudits.FindAsync(id);

            if (assetDetailsAudit == null)
            {
                return NotFound();
            }

            return assetDetailsAudit;
        }

        // POST: api/AssetDetailsAudit
        [HttpPost]
        public async Task<ActionResult<AssetDetailsAudit>> PostAssetDetailsAudit(AssetDetailsAudit assetDetailsAudit)
        {
            _context.AssetDetailsAudits.Add(assetDetailsAudit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssetDetailsAudit", new { id = assetDetailsAudit.Id }, assetDetailsAudit);
        }


        // PUT: api/AssetDetailsAudit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssetDetailsAudit(int id, AssetDetailsAudit assetDetailsAudit)
        {
            if (id != assetDetailsAudit.Id)
            {
                return BadRequest();
            }

            _context.Entry(assetDetailsAudit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetDetailsAuditExists(id))
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

        // DELETE: api/AssetDetailsAudit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssetDetailsAudit(int id)
        {
            var assetDetailsAudit = await _context.AssetDetailsAudits.FindAsync(id);
            if (assetDetailsAudit == null)
            {
                return NotFound();
            }

            _context.AssetDetailsAudits.Remove(assetDetailsAudit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssetDetailsAuditExists(int id)
        {
            return _context.AssetDetailsAudits.Any(e => e.Id == id);
        }
    }
}
