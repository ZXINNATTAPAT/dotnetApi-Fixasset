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
        private readonly ILogger<AssetDetailsController> _logger;

        public AssetDetailsController(AssetsContext context ,ILogger<AssetDetailsController> logger)
        {
            _context = context;
            _logger = logger;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssetDetails(int id, AssetDetails assetDetails)
        {
            if (id != assetDetails.AssetId)
            {
                return BadRequest();
            }

            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    var entityEntry = _context.Entry(assetDetails);

                    // Load original values
                    var originalAsset = await _context.AssetDetails.AsNoTracking().FirstOrDefaultAsync(a => a.AssetId == id);
                    if (originalAsset == null)
                    {
                        return NotFound();
                    }

                    var auditRecords = new List<AssetDetailsAudit>();

                    foreach (var property in entityEntry.Properties)
                    {
                        var originalValue = originalAsset.GetType().GetProperty(property.Metadata.Name)?.GetValue(originalAsset, null);
                        var currentValue = property.CurrentValue;

                        // Check for changes and log them if necessary
                        if (!Equals(originalValue, currentValue))
                        {
                            auditRecords.Add(new AssetDetailsAudit
                            {
                                AssetId = assetDetails.AssetId,
                                PropertyName = property.Metadata.Name,
                                OldValue = originalValue?.ToString(),
                                NewValue = currentValue?.ToString(),
                                ModifiedDate = DateTime.UtcNow,
                                ModifiedBy = "current_user" // Replace with actual user ID or name
                            });
                        }
                    }

                    // Mark entity as modified
                    entityEntry.State = EntityState.Modified;

                    // Save changes in AssetDetails
                    await _context.SaveChangesAsync();

                    // Save audit records if there are any changes
                    if (auditRecords.Any())
                    {
                        await _context.AssetDetailsAudits.AddRangeAsync(auditRecords);
                        await _context.SaveChangesAsync();
                    }

                    // Commit transaction
                    await transaction.CommitAsync();
                }

                // Invalidate cache for GetAssetDetails action
                Response.Headers["Cache-Control"] = "no-cache";

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception details for better troubleshooting
                _logger.LogError(ex, "An error occurred while saving asset details.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while saving asset details.");
            }
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
