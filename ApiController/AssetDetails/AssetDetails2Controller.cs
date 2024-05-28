using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetDetails2Controller : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetDetails2Controller(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/AssetDetails2
        [HttpGet]
        public ActionResult<IEnumerable<AssetDetails2>> GetAssetDetails()
        {
            var assetDetails = _context.AssetDetails2;

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

        // GET: api/AssetDetails2/5
        [HttpGet("{id}")]
        public ActionResult<AssetDetails2> GetAssetDetails2(int id)
        {
            var assetDetails2 = _context.AssetDetails2?.Find(id);

            if (assetDetails2 == null)
            {
                return NotFound();
            }

            return assetDetails2;
        }

        // POST: api/AssetDetails2
        [HttpPost]
        public ActionResult<AssetDetails2> PostAssetDetails2(AssetDetails2 assetDetails2)
        {
            _context.AssetDetails2?.Add(assetDetails2);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAssetDetails2), new { id = assetDetails2.AssetDetailId }, assetDetails2);
        }

        // PUT: api/AssetDetails2/5
        [HttpPut("{id}")]
        public IActionResult PutAssetDetails2(int id, AssetDetails2 assetDetails2)
        {
            if (id != assetDetails2.AssetDetailId)
            {
                return BadRequest();
            }

            _context.Entry(assetDetails2).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/AssetDetails2/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAssetDetails2(int id)
        {
            var assetDetails2 = _context.AssetDetails2?.Find(id);

            if (assetDetails2 == null)
            {
                return NotFound();
            }

            _context.AssetDetails2?.Remove(assetDetails2);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
