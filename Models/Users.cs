using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string? CodeId { get; set; } //รหัสพนักงาน

        [Required]
        [MaxLength(50)]
        public string? Username { get; set; } //ใช้ Emails

        [Required]
        [MaxLength(10)]
        public string? prefix { get; set; } // คำนำหน้า

        [Required]
        [MaxLength(50)]
        public string? Sname { get; set; } //ชื้อ

        [Required]
        [MaxLength(50)]
        public string? Lname { get; set; } //นามสกุล

        [Required]
        public string? Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string? position { get; set; } //ต่ำแหน่ง

        [Required]
        [MaxLength(50)]
        public string? subposition { get; set; } //ต่ำแหน่งในสาย

        [Required]
        [MaxLength(50)]
        public string? workgroup { get; set; } //กลุ่มงาน ฝ่าย สำนักงาน

        [Required]
        [MaxLength(50)]
        public string? affiliation { get; set; } //สังกัด

        [Required]
        [MaxLength(50)]
        public string? positiontype { get; set; } //ประเภทต่ำแหน่ง

        public DateTime EnrollmentDate { get; set; }

        public string? Roles { get; set; } // สิทธิของผู้ใช้

        // Hash the password before saving to the database
        public void HashPassword()
        {
            if (Password != null)
            {
                using (var sha256 = SHA256.Create())
                {
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                    Password = Convert.ToBase64String(hashedBytes);
                }
            }
        }
    }
}
