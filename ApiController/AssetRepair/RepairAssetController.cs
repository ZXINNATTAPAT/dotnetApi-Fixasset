using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairAssetController : ControllerBase
    {
        private readonly AssetsContext _context;

        public RepairAssetController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/RepairAsset
        [HttpGet]
         public ActionResult<IEnumerable<RepairAsset>> GetAssetDetails()
        {
            var assetDetails = _context.RepairAssets;

            if (assetDetails != null)
            {
                return assetDetails.ToList();
            }
            else
            {
                // Handle the case where assetDetails is null
                // For example, return a 404 Not Found response or throw an exception
                return NotFound();
            }
        }

        // GET: api/RepairAsset/5
        [HttpGet("{id}")]
        public ActionResult<RepairAsset> GetRepairAsset(int id)
        {
            var repairAsset = _context.RepairAssets?.Find(id);

            if (repairAsset == null)
            {
                return NotFound();
            }

            return repairAsset;
        }

        // POST: api/RepairAsset
        [HttpPost]
        public ActionResult<RepairAsset> PostRepairAsset(RepairAsset repairAsset)
        {
            _context.RepairAssets?.Add(repairAsset);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRepairAsset), new { id = repairAsset.RepairAssetId }, repairAsset);
        }

        // PUT: api/RepairAsset/5
        [HttpPut("{id}")]
        public IActionResult PutRepairAsset(int id, RepairAsset repairAsset)
        {
            if (id != repairAsset.RepairAssetId)
            {
                return BadRequest();
            }

            _context.Entry(repairAsset).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/RepairAsset/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRepairAsset(int id)
        {
            var repairAsset = _context.RepairAssets?.Find(id);

            if (repairAsset == null)
            {
                return NotFound();
            }

            _context.RepairAssets?.Remove(repairAsset);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
