using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Sectiontypecode
    {
        [Key]
        public int SectionId { get; set; }

        public string? Sectioncode { get; set; }

        public string? SectionName { get; set; }

        // public ICollection<Assetcategory> Assetcategories { get; set; } = new List<Assetcategory>();
    }
}


    
