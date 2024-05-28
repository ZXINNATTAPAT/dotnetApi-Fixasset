using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AssetDetails2
    {
        [Key]
        public int AssetDetailId { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public string? SerialNumber { get; set; }

        public string? InvoiceNumber { get; set; }

        public string? PaymentVoucherNumber { get; set; }

        public string? InsurancePolicyNumber { get; set; }

        public string? InsuranceNumber { get; set; }

        public string? InsuranceCompany { get; set; }

        public decimal InsurancePremium { get; set; }

        public int InsuranceAge { get; set; }

        public DateTime InsuranceStartDate { get; set; }

        public DateTime InsuranceEndDate { get; set; }

        public string? MaintenanceRecommendation { get; set; }

        [ForeignKey("AssetDetails")]
        public int AssetId { get; set; }
        public AssetDetails? AssetDetails { get; set; }
    }
}
