using core_identity_demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace core_identity_demo.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileBadge> profileBadges { get; set; }
        public DbSet<Badge> badges { get; set; }
        public DbSet<DeactivatedProfile> deactivatedProfiles { get; set; }
    }

    public class DeactivatedProfile
    {
    }
    public class Badge
    {

    }
    public class ProfileBadge
    {

    }
    public class Profile
    {

    }
}