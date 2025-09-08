using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SecureTaskApp.Services
{
    public static class RoleInitializer
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            // 1. Create roles
            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // 2. Create Admin user
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // 3. Create regular User with claim
            var userEmail = "user@example.com";
            var appUser = await userManager.FindByEmailAsync(userEmail);
            if (appUser == null)
            {
                appUser = new IdentityUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(appUser, "User@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "User");
                    await userManager.AddClaimAsync(appUser, new Claim("CanEditTask", "true"));
                }
            }
        }
    }
}
