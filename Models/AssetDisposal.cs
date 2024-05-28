using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AssetDisposal
    {
        [Key]
        public int DisposalId { get; set; }

        public string? AssetCode { get; set; }

        public string? AssetName { get; set; }

        public string? DocumentNumber { get; set; }

        public DateTime DisposalDate { get; set; }

        public string? Description { get; set; }
    }
}
