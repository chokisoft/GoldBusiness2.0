using GoldBusiness.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace APIGoldBusiness.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var configuration = services.GetRequiredService<IConfiguration>();

            // Crear roles si no existen
            string[] roles = { "Admin", "Manager", "User", "Cashier", "Accountant", "Auditor" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Crear usuario admin si no existe
            var adminEmail = configuration["AdminUser:Email"] ?? "admin@goldbusiness.com";
            var adminPassword = configuration["AdminUser:Password"] ?? "Admin123!";
            var adminFirstName = configuration["AdminUser:FirstName"] ?? "Admin";
            var adminLastName = configuration["AdminUser:LastName"] ?? "System";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = adminFirstName,
                    LastName = adminLastName,
                    EmailConfirmed = true,
                    IsActive = true,
                    PhoneNumber = "+1234567890"
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    await userManager.AddToRoleAsync(adminUser, "User");

                    // Agregar claims de permisos al admin
                    await userManager.AddClaimAsync(adminUser, new Claim("perm.dashboard", "full"));
                    await userManager.AddClaimAsync(adminUser, new Claim("perm.users", "full"));
                    await userManager.AddClaimAsync(adminUser, new Claim("perm.reports", "full"));
                    await userManager.AddClaimAsync(adminUser, new Claim("perm.settings", "full"));
                    await userManager.AddClaimAsync(adminUser, new Claim("perm.data", "level4"));
                }
            }
        }
    }
}