using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AssetDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }

        [Required]
        public string? AssetCode { get; set; }

        [Required]
        public string? AssetName { get; set; }

        public int Quantity { get; set; }

        public string? Unit { get; set; }

        public string? PurchasedFrom { get; set; }

        public string? AssetType { get; set; }

        public string? AssetCategory { get; set; }

        public string? Department { get; set; }

        public string? Agency { get; set; } //สำนัก

        public string? AssetLocation { get; set; }

        // [ForeignKey("ResponsibleEmployee")]
        // public int CodeId { get; set; }
        public string? ResponsibleEmployee { get; set; }

        public string? DocumentNumber { get; set; }

        public string? TaxInvoiceNumber { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime ReceiptDate { get; set; }

        public DateTime DepreciationStartDate { get; set; }

        public DateTime DepreciationCalculationStartDate { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal CalculatedPrice { get; set; }

        public decimal ScrapPrice { get; set; }

        public decimal DepreciationRate { get; set; }

        public int AssetAge { get; set; }

        public DateTime DepreciationEndDate { get; set; }

        public decimal AccumulatedDepreciation { get; set; }

        public decimal DepreciationValue { get; set; }

        public decimal BookValue { get; set; }

        public string? Status { get; set; }
        
        public string? Note { get; set; }

        // public string? ImageUrl { get; set; }
    }
}
