using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Factiontypecode
    {
        [Key]
        public int Id { get; set; }

        public string? FactionCode { get; set; }//รหัสที่อยู่

        public string? FactionName { get; set; }//ที่อยู่

    }
}
