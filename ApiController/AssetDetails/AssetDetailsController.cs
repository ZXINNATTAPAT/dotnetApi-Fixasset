using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetDetailsController : ControllerBase
    {
        private readonly AssetsContext _context;

        public AssetDetailsController(AssetsContext context)
        {
            _context = context;
        }

        // GET: api/AssetDetails
        [HttpGet]
        // [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)] 
        public ActionResult<IEnumerable<AssetDetails>> GetAssetDetails()
        {
            var assetDetails = _context.AssetDetails;

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

        // GET: api/AssetDetails/5
        [HttpGet("{id}")]
        public ActionResult<AssetDetails> GetAssetDetails(int id)
        {
            var assetDetails = _context.AssetDetails?.Find(id);

            if (assetDetails == null)
            {
                return NotFound();
            }

            return assetDetails;
        }

    //     // GET: api/AssetDetails/5
    //    [HttpGet("byassetcode/{AssetCode}")]
    //     public ActionResult<IActionResult> GetAssetDetails(string AssetCode)
    //     {
    //         var assetDetails = _context.AssetDetails?.FirstOrDefault(ad => ad.AssetCode == AssetCode);

    //         if (assetDetails == null)
    //         {
    //             return NotFound();
    //         }

    //         return Ok(assetDetails);
    //     }


        // POST: api/AssetDetails
    //    [HttpPost]
    //     public ActionResult<AssetDetails> PostAssetDetails(AssetDetails assetDetails)
    //     {
    //         // if (assetDetails == null)
    //         // {
    //         //     return BadRequest("Invalid request data.");
    //         // }

    //         try
    //         {
    //             // Check if there is an existing asset with the same AssetCode
    //             var existingAsset = _context.AssetDetails.FirstOrDefault(a => a.AssetCode == assetDetails.AssetCode);

    //             // If an existing asset is found, modify the AssetCode to make it unique
    //             if (existingAsset != null)
    //             {
    //                 assetDetails.AssetCode = GetUniqueAssetCode(assetDetails.AssetCode);
    //             }

    //             // Add the assetDetails to the context and save changes
    //             _context.AssetDetails.Add(assetDetails);
    //             _context.SaveChanges();
    //         }
    //         catch (Exception ex)
    //         {
    //             // Log the exception
    //             Console.WriteLine(ex.ToString());
    //             return StatusCode(500, $"An error occurred while processing the request. {ex.Message}");
    //         }

    //         // Return a response indicating successful creation
    //         return CreatedAtAction(nameof(GetAssetDetails), new { id = assetDetails.AssetId }, assetDetails);
    //     }

    //    private string GetUniqueAssetCode(string assetCode)
    //     {
    //         if (!IsValidAssetCode(assetCode))
    //         {
    //             throw new FormatException("AssetCode format is invalid.");
    //         }

    //         var parts = assetCode.Split('-');
    //         var baseAssetCode = $"{parts[0]}-{parts[1]}-";
    //         var suffix = int.Parse(parts[2]);
    //         var extension = parts[3];

    //         while (_context.AssetDetails.Any(a => a.AssetCode == assetCode))
    //         {
    //             suffix++;
    //             if (suffix > 999)
    //             {
    //                 throw new OverflowException("Maximum suffix value reached.");
    //             }
    //             assetCode = $"{baseAssetCode}{suffix:D3}-{extension}";
    //         }

    //         return assetCode;
    //     }
    //     private bool IsValidAssetCode(string assetCode)
    //     {
    //         return Regex.IsMatch(assetCode, @"^[a-zA-Z]+\d{4}-\d{3}-\d{4}$");
    //     }
                    
        [HttpPost]
        public ActionResult<AssetDetails> PostAssetDetails(AssetDetails assetDetails)
        {
            // Check if there is an existing asset with the same AssetCode
            var existingAsset = _context.AssetDetails.FirstOrDefault(a => a.AssetCode == assetDetails.AssetCode);

            // If an existing asset is found, modify the AssetCode to make it unique
            if (existingAsset != null)
            {
                assetDetails.AssetCode += $"({GetAssetCodeCount(assetDetails.AssetCode)})";
            }

            // Add the assetDetails to the context and save changes
            _context.AssetDetails.Add(assetDetails);
            _context.SaveChanges();

            // Invalidate cache for GetAssetDetails action
            Response.Headers["Cache-Control"] = "no-cache";

            // Return a response indicating successful creation
            return CreatedAtAction(nameof(GetAssetDetails), new { id = assetDetails.AssetId }, assetDetails);
        }

        // Method to get the count of assets with the same AssetCode prefix
        private int GetAssetCodeCount(string assetCode)
        {
            return _context.AssetDetails.Count(a => a.AssetCode.StartsWith(assetCode));
        }

        // PUT: api/AssetDetails/5
        [HttpPut("{id}")]
        public IActionResult PutAssetDetails(int id, AssetDetails assetDetails)
        {
            if (id != assetDetails.AssetId)
            {
                return BadRequest();
            }

            _context.Entry(assetDetails).State = EntityState.Modified;
            _context.SaveChanges();

            // Invalidate cache for GetAssetDetails action
            Response.Headers["Cache-Control"] = "no-cache";

            return NoContent();
        }

        // DELETE: api/AssetDetails/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAssetDetails(int id)
        {
            var assetDetails = _context.AssetDetails?.Find(id);

            if (assetDetails == null)
            {
                return NotFound();
            }

            _context.AssetDetails?.Remove(assetDetails);
            _context.SaveChanges();

            // Invalidate cache for GetAssetDetails action
            Response.Headers["Cache-Control"] = "no-cache";

            return NoContent();
        }
    }
}
