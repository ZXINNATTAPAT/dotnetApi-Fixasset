using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetSharingController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetSharingController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/AssetSharing
        [HttpGet]
         public ActionResult<IEnumerable<AssetSharing>> GetAssetDetails()
        {
            var assetDetails = _context.AssetSharing;

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

        // GET: api/AssetSharing/5
        [HttpGet("{id}")]
        public ActionResult<AssetSharing> GetAssetSharing(int id)
        {
            var assetSharing = _context.AssetSharing?.Find(id);

            if (assetSharing == null)
            {
                return NotFound();
            }

            return assetSharing;
        }

        // POST: api/AssetSharing
        [HttpPost]
        public ActionResult<AssetSharing> PostAssetSharing(AssetSharing assetSharing)
        {
            _context.AssetSharing?.Add(assetSharing);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAssetSharing), new { id = assetSharing.SharingId }, assetSharing);
        }

        // PUT: api/AssetSharing/5
        [HttpPut("{id}")]
        public IActionResult PutAssetSharing(int id, AssetSharing assetSharing)
        {
            if (id != assetSharing.SharingId)
            {
                return BadRequest();
            }

            _context.Entry(assetSharing).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/AssetSharing/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAssetSharing(int id)
        {
            var assetSharing = _context.AssetSharing?.Find(id);

            if (assetSharing == null)
            {
                return NotFound();
            }

            _context.AssetSharing?.Remove(assetSharing);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
