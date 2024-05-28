using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Assettypecode
    {
        [Key]
        public int Id { get; set; }

        public string? AssetCode { get; set; }

        public string? AssetName { get; set; }

        public string? Rate_dep { get; set; } // อัตราค่าเสื่อม

        public string? Servicelife { get; set; } // อายุการใช้งาน

    }
}
