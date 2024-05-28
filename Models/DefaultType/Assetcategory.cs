using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
   public class Assetcategory // หมวด
    {
        [Key]
        public int Id { get; set; }

        public string? Asc_Code { get; set; } 

        public string? Asc_Name { get; set; } 

        public string? AssetCode { get; set; }
        //ใช้กับประเภทครุภัฑณ์ 
    }
}