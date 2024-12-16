using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLquanCafe.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required, MaxLength(100)]
        public  string ProductName { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}