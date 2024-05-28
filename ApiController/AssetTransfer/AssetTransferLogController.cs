using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTransferLogController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetTransferLogController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/AssetTransferLog
        [HttpGet]
         public ActionResult<IEnumerable<AssetTransferLog>> GetAssetDetails()
        {
            var assetDetails = _context.AssetTransferLogs;

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

        // GET: api/AssetTransferLog/5
        [HttpGet("{id}")]
        public ActionResult<AssetTransferLog> GetAssetTransferLog(int id)
        {
            var assetTransferLog = _context.AssetTransferLogs?.Find(id);

            if (assetTransferLog == null)
            {
                return NotFound();
            }

            return assetTransferLog;
        }

        // POST: api/AssetTransferLog
        [HttpPost]
        public ActionResult<AssetTransferLog> PostAssetTransferLog(AssetTransferLog assetTransferLog)
        {
            _context.AssetTransferLogs?.Add(assetTransferLog);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAssetTransferLog), new { id = assetTransferLog.TransferId }, assetTransferLog);
        }

        // PUT: api/AssetTransferLog/5
        [HttpPut("{id}")]
        public IActionResult PutAssetTransferLog(int id, AssetTransferLog assetTransferLog)
        {
            if (id != assetTransferLog.TransferId)
            {
                return BadRequest();
            }

            _context.Entry(assetTransferLog).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/AssetTransferLog/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAssetTransferLog(int id)
        {
            var assetTransferLog = _context.AssetTransferLogs?.Find(id);

            if (assetTransferLog == null)
            {
                return NotFound();
            }

            _context.AssetTransferLogs?.Remove(assetTransferLog);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
