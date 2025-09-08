using Microsoft.EntityFrameworkCore;
using EFCoreExamples.Models;

namespace EFCoreExamples.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }
        public DbSet<Information> Information { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // Configure Department entity
        //     modelBuilder.Entity<Information>(entity =>
        //     {
        //         entity.Property(e => e.Name)
        //             .IsRequired()
        //             .HasMaxLength(50)
        //             .IsUnicode(false);
        //     });
        // }
    }
}