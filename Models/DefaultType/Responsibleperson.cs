using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Responsibleperson
    {
        [Key]
        public int Id { get; set; }

        public string? RP_Code { get; set; }//รหัสที่อยู่

        public string? RP_Name { get; set; }//ที่อยู่
    }
}