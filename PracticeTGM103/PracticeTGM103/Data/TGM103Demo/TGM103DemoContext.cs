using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticeTGM103.Models.Products;

namespace PracticeTGM103.Data.TGM103Demo
{
    public class TGM103DemoContext : DbContext
    {
        //TODO 自訂建構子
        public TGM103DemoContext(DbContextOptions<TGM103DemoContext> options)
            : base(options)
        {
        }

        public DbSet<Members> Members { get; set; }
        public DbSet<Products> Products { get; set; }

        //TODO Override覆寫原本的方法()

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>().ToTable("Members");
            modelBuilder.Entity<Products>().ToTable("Products");
        }
    }
}