using GurventVantilator.Infrastructure.Identity;
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
            // Veritabanını oluştur / migrate et
            await context.Database.MigrateAsync();

            // 1️⃣ Rolleri oluştur
            string[] roles = { "DevAdmin", "Admin", "User" };
            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var role = new ApplicationRole
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpper(),
                        Description = roleName switch
                        {
                            "DevAdmin" => "Tüm yetkilere sahip geliştirici",
                            "Admin" => "Yönetim paneli yöneticisi",
                            "User" => "Sadece WebUI tarafında oturum açabilir",
                            _ => null
                        }
                    };
                    await roleManager.CreateAsync(role);
                }
            }

            // 2️⃣ DevAdmin kullanıcısı
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
                    await userManager.AddToRolesAsync(user, new[] { "DevAdmin", "Admin" });
                }
            }

            // 3️⃣ Admin kullanıcısı
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
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
