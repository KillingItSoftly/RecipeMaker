using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeManager.Web.Data
{
    public class UserRoleService : IUserRoleService
    {
        public const string ADMIN_ROLE_NAME = "Admin";
        public const string ADMIN_ROLE_EMAIL = "hello@world.com";
        public const string ADMIN_ROLE_PASSWORD = "P@ssW0rd!!";
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        private async Task EnsureRoles()
        {
            var existingRole = await _roleManager.FindByNameAsync(ADMIN_ROLE_NAME);
            if (existingRole == null)
            {
                var adminRole = new IdentityRole()
                {
                    Name = ADMIN_ROLE_NAME,
                    NormalizedName = ADMIN_ROLE_NAME.ToUpper()
                };
                await _roleManager.CreateAsync(adminRole);  
            }
        }
        private async Task EnsureUsers()
        {
            var existingUser = await _userManager.FindByEmailAsync(ADMIN_ROLE_EMAIL);
            if (existingUser == null)
            {
                var adminUser = new IdentityUser()
                {
                    Email = ADMIN_ROLE_EMAIL,
                    EmailConfirmed = true,
                    UserName = ADMIN_ROLE_EMAIL,
                    NormalizedEmail = ADMIN_ROLE_EMAIL.ToUpper(),
                    NormalizedUserName = ADMIN_ROLE_EMAIL.ToUpper(),
                    LockoutEnabled = true,
                };
                await _userManager.CreateAsync(adminUser, ADMIN_ROLE_PASSWORD);
            }
        }

        public async Task EnsureAdminUserRole()
        {
            await EnsureRoles();
            await EnsureUsers();
            var existingAdminUser = await _userManager.FindByEmailAsync(ADMIN_ROLE_EMAIL);
            var existingRole = await _roleManager.FindByNameAsync(ADMIN_ROLE_NAME);
            if (existingAdminUser == null || existingRole == null)
            {
                throw new InvalidOperationException("Cannot add null user or role");
            }
            var userRoles = await _userManager.GetRolesAsync(existingAdminUser);
            var existingUserAdminRole = userRoles.SingleOrDefault(x => x.Equals(ADMIN_ROLE_NAME));
            if (existingUserAdminRole == null)
            {
                await _userManager.AddToRoleAsync(existingAdminUser, ADMIN_ROLE_NAME);
            }
        }
    }
}
