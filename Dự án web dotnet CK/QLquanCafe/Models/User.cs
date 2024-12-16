using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLquanCafe.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public  string FullName { get; set; }

        [Required, MaxLength(100)]
        public  string Email { get; set; }

        [Required, MaxLength(256)]
        public  string Password { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }

    public enum UserRole
    {
        Customer,
        Staff,
        Admin
    }
}