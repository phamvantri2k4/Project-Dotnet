using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace QLquanCafe.Models
{
    public class AppDbContext : DbContext // Đổi tên DbContext thành AppDbContext
    {
        // Constructor nhận DbContextOptions<AppDbContext>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tables> Tables { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
