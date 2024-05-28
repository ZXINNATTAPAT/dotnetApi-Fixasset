using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetInventoryController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetInventoryController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/AssetInventory
        [HttpGet]
        public ActionResult<IEnumerable<AssetInventory>> GetAssetDetails()
        {
            var assetDetails = _context.AssetInventory;

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

        // GET: api/AssetInventory/5
        [HttpGet("{id}")]
        public ActionResult<AssetInventory> GetAssetInventory(int id)
        {
            var assetInventory = _context.AssetInventory?.Find(id);

            if (assetInventory == null)
            {
                return NotFound();
            }

            return assetInventory;
        }

        // POST: api/AssetInventory
        // [HttpPost]
        // public ActionResult<AssetInventory> PostAssetInventory(AssetInventory assetInventory)
        // {
        //     _context.AssetInventory?.Add(assetInventory);
        //     _context.SaveChanges();

        //     return CreatedAtAction(nameof(GetAssetInventory), new { id = assetInventory.InventoryId }, assetInventory);
        // }

        [HttpPost]
        public ActionResult<AssetInventory> PostAssetInventory(AssetInventory assetInventory)
        {
            // Check if there is any existing asset inventory with the same SerialNumber and Date
            bool isExisting = _context.AssetInventory
                .Any(ai => ai.SerialNumber == assetInventory.SerialNumber && ai.Date == assetInventory.Date);

            if (isExisting)
            {
                // If a record with the same SerialNumber and Date exists, do not increment SerialNumber
                _context.AssetInventory?.Add(assetInventory);
            }
            else
            {
                // If no record with the same SerialNumber and Date exists, increment SerialNumber
                assetInventory.SerialNumber = IncrementSerialNumber(assetInventory.SerialNumber);
                _context.AssetInventory?.Add(assetInventory);
            }

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAssetInventory), new { id = assetInventory.InventoryId }, assetInventory);
        }


        // Function to check if the SerialNumber already exists
        private bool IsSerialNumberExists(string serialNumber)
        {
            return _context.AssetInventory.Any(ai => ai.SerialNumber == serialNumber);
        }

        // Function to increment the last 4 digits of a SerialNumber
        private string IncrementSerialNumber(string serialNumber)
        {
            // Extract the last 4 digits of the SerialNumber
            string lastDigits = serialNumber.Substring(serialNumber.Length - 4);

            // Convert the last 4 digits to an integer and increment by 1
            int lastNumber = int.Parse(lastDigits) + 1;

            // Format the incremented number to have 4 digits
            string incrementedDigits = lastNumber.ToString().PadLeft(4, '0');

            // Replace the last 4 digits in the SerialNumber with the incremented digits
            string incrementedSerialNumber = serialNumber.Substring(0, serialNumber.Length - 4) + incrementedDigits;

            return incrementedSerialNumber;
        }


        


        // PUT: api/AssetInventory/5
        [HttpPut("{id}")]
        public IActionResult PutAssetInventory(int id, AssetInventory assetInventory)
        {
            if (id != assetInventory.InventoryId)
            {
                return BadRequest();
            }

            _context.Entry(assetInventory).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/AssetInventory/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAssetInventory(int id)
        {
            var assetInventory = _context.AssetInventory?.Find(id);

            if (assetInventory == null)
            {
                return NotFound();
            }

            _context.AssetInventory?.Remove(assetInventory);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
