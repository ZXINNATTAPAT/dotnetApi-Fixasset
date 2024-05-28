using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Countingunit
    {
        [Key]
        public int Id { get; set; }

        public string? unitCode { get; set; }//รหัสที่อยู่

        public string? unitName { get; set; }//ที่อยู่
    }
}