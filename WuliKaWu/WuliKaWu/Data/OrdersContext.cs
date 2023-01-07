using Microsoft.EntityFrameworkCore;
using WuliKaWu.Models;

namespace WuliKaWu.Data
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {
        }

        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>().ToTable("Orders");
        }
    }
}