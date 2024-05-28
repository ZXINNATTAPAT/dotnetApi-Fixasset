using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetDisposalController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetDisposalController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/AssetDisposal
        [HttpGet]
        public ActionResult<IEnumerable<AssetDisposal>> GetAssetDetails()
        {
            var assetDetails = _context.AssetDisposals;

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
        // GET: api/AssetDisposal/5
        [HttpGet("{id}")]
        public ActionResult<AssetDisposal> GetAssetDisposal(int id)
        {
            var assetDisposal = _context.AssetDisposals?.Find(id);

            if (assetDisposal == null)
            {
                return NotFound();
            }

            return assetDisposal;
        }

        // POST: api/AssetDisposal
        [HttpPost]
        public ActionResult<AssetDisposal> PostAssetDisposal(AssetDisposal assetDisposal)
        {
            _context.AssetDisposals?.Add(assetDisposal);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAssetDisposal), new { id = assetDisposal.DisposalId }, assetDisposal);
        }

        // PUT: api/AssetDisposal/5
        [HttpPut("{id}")]
        public IActionResult PutAssetDisposal(int id, AssetDisposal assetDisposal)
        {
            if (id != assetDisposal.DisposalId)
            {
                return BadRequest();
            }

            _context.Entry(assetDisposal).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/AssetDisposal/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAssetDisposal(int id)
        {
            var assetDisposal = _context.AssetDisposals?.Find(id);

            if (assetDisposal == null)
            {
                return NotFound();
            }

            _context.AssetDisposals?.Remove(assetDisposal);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
