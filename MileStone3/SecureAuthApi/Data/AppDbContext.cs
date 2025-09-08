using Microsoft.EntityFrameworkCore;
using SecureAuthApi.Models;

namespace SecureAuthApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    public DbSet<SecureData> SecureDatas => Set<SecureData>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.Username).IsUnique();
    }
}
