using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class PropertySeller
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Seller Code is required")]
    public string? SellerCode { get; set; }

    [Required(ErrorMessage = "Seller Name is required")]
    public string? SellerName { get; set; }

    public string? Address { get; set; }

    public string? Tel { get; set; }

    public string? Telfax { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }

    // [Url(ErrorMessage = "Invalid URL")]
    public string? Homepage { get; set; }

    [Required(ErrorMessage = "TIN number is required")]
    public string? TinNumber { get; set; } // เลขประจำตัวผู้เสียภาษี
}

}