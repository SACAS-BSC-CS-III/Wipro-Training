using Microsoft.AspNetCore.Identity;
using RoleAuthApp.Models;

namespace RoleAuthApp.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();

            string[] roles = new[] { "Admin", "User" };

            // Create roles if they don't exist
            foreach (var r in roles)
            {
                if (!await roleManager.RoleExistsAsync(r))
                    await roleManager.CreateAsync(new IdentityRole(r));
            }

            // Create Admin user
            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create a normal user
            var normalUser = await userManager.FindByNameAsync("user1");
            if (normalUser == null)
            {
                normalUser = new AppUser
                {
                    UserName = "user1",
                    Email = "user1@example.com",
                    EmailConfirmed = true
                };

                var res = await userManager.CreateAsync(normalUser, "User@1234");
                if (res.Succeeded)
                {
                    await userManager.AddToRoleAsync(normalUser, "User");
                }
            }
        }
    }
}
