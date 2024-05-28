using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AssetSharing
    {
        [Key]
        public int SharingId { get; set; }

        public string? AssetCode { get; set; }

        public string? AssetName { get; set; }

        public string? DocumentNumber { get; set; }

        public DateTime DocumentDate { get; set; }

        public string? Description { get; set; }

        public string? DepartmentCode { get; set; }

        public string? DepartmentName { get; set; }

        public decimal Rate { get; set; }
    }
}
