using GurventVantilator.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace GurventVantilator.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(
            AppDbContext context,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            await context.Database.MigrateAsync();

            // 1️⃣ Roller
            string[] roles = { "Admin", "DevAdmin" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new ApplicationRole(role));
            }

            // 2️⃣ DevAdmin kullanıcı
            var devEmail = "devadmin@firatramazano.com";
            var devUser = await userManager.FindByEmailAsync(devEmail);
            if (devUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "DevAdmin",
                    Email = devEmail,
                    EmailConfirmed = true,
                    FirstName = "Fırat",
                    LastName = "Ramazano",
                    IsActive = true
                };

                var result = await userManager.CreateAsync(user, "DevAdmin!123");
                if (result.Succeeded)
                {
                    // 🔹 DevAdmin hem DevAdmin hem Admin rolüne sahip
                    await userManager.AddToRolesAsync(user, new[] { "DevAdmin", "Admin" });
                }
            }

            // 3️⃣ Admin kullanıcı
            var adminEmail = "admin@firatramazano.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Gürsel",
                    LastName = "Eracun",
                    IsActive = true
                };

                var result = await userManager.CreateAsync(user, "Admin!123");
                if (result.Succeeded)
                {
                    // 🔹 Admin sadece Admin rolüne sahip
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
