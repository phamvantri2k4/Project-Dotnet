using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLquanCafe.Models
{
    public class Tables
    {
        [Key]
        public int TableId { get; set; }

        [Required, MaxLength(50)]
        public string TableName { get; set; }

        [Required]
        public bool Status { get; set; } // true if occupied, false if available

        public ICollection<Orders> Orders { get; set; }
    }
}