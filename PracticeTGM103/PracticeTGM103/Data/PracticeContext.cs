using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticeTGM103.Models;

namespace PracticeTGM103.Data
{
    public class PracticeContext : DbContext
    {
        //TODO 自訂建構子
        public PracticeContext(DbContextOptions<PracticeContext> options)
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