using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetDetails3Controller : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetDetails3Controller(AssetsContext context)
        {
            _context = context;
        }

       // GET: api/AssetDetails3
        [HttpGet]
        public ActionResult<IEnumerable<AssetDetails3>> GetAssetDetails()
        {
            var assetDetails = _context.AssetDetails3;

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

        // GET: api/AssetDetails3/5
        [HttpGet("{id}")]
        public ActionResult<AssetDetails3> GetAssetDetails3(int id)
        {
            var assetDetails3 = _context.AssetDetails3?.Find(id);

            if (assetDetails3 == null)
            {
                return NotFound();
            }

            return assetDetails3;
        }

        // POST: api/AssetDetails3
        [HttpPost]
        public ActionResult<AssetDetails3> PostAssetDetails3(AssetDetails3 assetDetails3)
        {
            _context.AssetDetails3?.Add(assetDetails3);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAssetDetails3), new { id = assetDetails3.AssetDetailId }, assetDetails3);
        }

        // PUT: api/AssetDetails3/5
        [HttpPut("{id}")]
        public IActionResult PutAssetDetails3(int id, AssetDetails3 assetDetails3)
        {
            if (id != assetDetails3.AssetDetailId)
            {
                return BadRequest();
            }

            _context.Entry(assetDetails3).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/AssetDetails3/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAssetDetails3(int id)
        {
            var assetDetails3 = _context.AssetDetails3?.Find(id);

            if (assetDetails3 == null)
            {
                return NotFound();
            }

            _context.AssetDetails3?.Remove(assetDetails3);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
