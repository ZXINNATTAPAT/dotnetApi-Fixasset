using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AssetDetails3
    {
        [Key]
        public int AssetDetailId { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal ShipWeight { get; set; }

        public decimal TransportCost { get; set; }

        public decimal InstallationCost { get; set; }

        public decimal OtherCost { get; set; }

        // public string? DebitAccount { get; set; }

        // public string? CreditAccount { get; set; }

        // [ForeignKey("Account")]
        // public Account Debit { get; set; }

        // [ForeignKey("Account")]
        // public Account Credit { get; set; }

        [ForeignKey("AssetDetails")]
        public int AssetId { get; set; }
        public AssetDetails? AssetDetails { get; set; }
    }
}
