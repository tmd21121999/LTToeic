using CoreLTToeic.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CoreLTToeic.Infrastructure.Data.Seeders
{
    public class AdminSeeder
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminSeeder(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            const string adminRole = "Admin";
            const string adminUserName = "admin";
            const string adminPassword = "admin";

            if (!await _roleManager.RoleExistsAsync(adminRole))
                await _roleManager.CreateAsync(new IdentityRole(adminRole));

            var adminUser = await _userManager.FindByNameAsync(adminUserName);
            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = adminUserName,
                    Email = "admin@lttoeic.local",
                    FullName = "Administrator",
                    EmailConfirmed = true,
                    CreateTime = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(adminUser, adminPassword);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Không thể tạo tài khoản admin: {errors}");
                }
            }

            if (!await _userManager.IsInRoleAsync(adminUser, adminRole))
                await _userManager.AddToRoleAsync(adminUser, adminRole);
        }
    }
}
