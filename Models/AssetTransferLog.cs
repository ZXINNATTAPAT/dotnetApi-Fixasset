using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AssetTransferLog
    {
        [Key]
        public int TransferId { get; set; }

        public DateTime Date { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? Note { get; set; }

        [ForeignKey("AssetDetails")]
        public int AssetId { get; set; }
        public AssetDetails? AssetDetails { get; set; }

        public string? AssetName { get; set; }

        public int Quantity { get; set; }

        public string? TransferredFrom { get; set; }

        public string? TransferredTo { get; set; }
    }
}
