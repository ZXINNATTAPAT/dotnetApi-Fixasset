using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetSalesController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetSalesController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/AssetSales
        [HttpGet]
         public ActionResult<IEnumerable<AssetSales>> GetAssetDetails()
        {
            var assetDetails = _context.AssetSales;

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

        // GET: api/AssetSales/5
        [HttpGet("{id}")]
        public ActionResult<AssetSales> GetAssetSales(int id)
        {
            var assetSales = _context.AssetSales?.Find(id);

            if (assetSales == null)
            {
                return NotFound();
            }

            return assetSales;
        }

        // POST: api/AssetSales
        [HttpPost]
        public ActionResult<AssetSales> PostAssetSales(AssetSales assetSales)
        {
            _context.AssetSales?.Add(assetSales);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAssetSales), new { id = assetSales.SaleId }, assetSales);
        }

        // PUT: api/AssetSales/5
        [HttpPut("{id}")]
        public IActionResult PutAssetSales(int id, AssetSales assetSales)
        {
            if (id != assetSales.SaleId)
            {
                return BadRequest();
            }

            _context.Entry(assetSales).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/AssetSales/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAssetSales(int id)
        {
            var assetSales = _context.AssetSales?.Find(id);

            if (assetSales == null)
            {
                return NotFound();
            }

            _context.AssetSales?.Remove(assetSales);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
