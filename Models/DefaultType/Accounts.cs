using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; }

        public string? Accounts_Code { get; set; }

        public string? Accounts_Name { get; set; }
    }
}