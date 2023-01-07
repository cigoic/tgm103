using Microsoft.EntityFrameworkCore;
using PracticeTGM103.Models.practice;

namespace PracticeTGM103.Data
{
    public class DemoContext : DbContext
    {
        //TODO
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }

        public DbSet<OrdersDemo> OrdersDemos { get; set; }

        public DbSet<MembersDemo> MembersDemos { get; set; }

        //TODO
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersDemo>().ToTable("OrdersDemo");
            modelBuilder.Entity<MembersDemo>().ToTable("MembersDemo");
        }
    }
}