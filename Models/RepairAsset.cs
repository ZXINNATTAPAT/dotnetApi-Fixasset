using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class RepairAsset
    {
        [Key]
        public int RepairAssetId { get; set; }

        [ForeignKey("AssetDetails")]
        public int AssetId { get; set; }
        public AssetDetails? AssetDetails { get; set; }

        public DateTime Date { get; set; }

        public string? SerialNumber { get; set; }

        public string? Description { get; set; }

        public decimal Amount { get; set; }
    }
}
