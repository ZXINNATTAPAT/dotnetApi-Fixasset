using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AssetInventory
    {
        [Key]
        public int InventoryId { get; set; }

        public DateTime Date { get; set; }

        public string? SerialNumber { get; set; }

        public string? DepartmentCode { get; set; }//รหัสแผนก

        public string? LocationCode { get; set; }//รหัสที่ตั้ง

        public string? Inspector { get; set; }

        public string? Verifier { get; set; }

        public string? Note { get; set; }

        [ForeignKey("AssetDetails")]
        public int AssetId { get; set; }
        public AssetDetails? AssetDetails { get; set; }

        public string? AssetName { get; set; }

        public decimal BookValue { get; set; }

        public decimal InventoryValue { get; set; }

        public decimal Difference => InventoryValue - BookValue;
    }
}
