using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
   public class Depreciation
   {
        [Key]
        public int Id { get; set; }

        public string? rate_dep { get; set; } // อัตราค่าเสื่อม

        public string? Servicelife { get; set; } // อายุการใช้งาน

        public string? AssetCode { get; set; } // อิงตามค่า AssetCode ของ AssetType

   }
}