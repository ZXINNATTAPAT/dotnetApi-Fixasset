using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AssetSales
    {
        [Key]
        public int SaleId { get; set; }

        public string? AssetCode { get; set; }

        public string? AssetName { get; set; }

        public string? Unit { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime SaleDate { get; set; }

        public string? DocumentNumber { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal BookValue { get; set; }
    }
}
