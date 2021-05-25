using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cella.BL.Permissions;
using Cella.Models;
using Cella.Models.Permissions;
using static WarehouseCrm.Web.Helpers.SeedRoles;

namespace WarehouseCrm.Web.Helpers
{
    public static class SeedUsers
    {



        public static async Task SeedAdminUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            var defaultUser = new ApplicationUser
            {
                UserName = "davidbuckleyweb@outlook.com",
                NormalizedUserName = "davidbuckleyweb@outlook.com",
                Email = "davidbuckleyweb@outlook.com",
                NormalizedEmail = "davidbuckleyweb@outlook.com",
                FirstName = "David",
                LastName = "Buckley",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };


            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(defaultUser, "Trafford2020d!");
            defaultUser.PasswordHash = hashed;
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser);
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }

               

                await roleManager.SeedClaimsForSuperAdminAsync();
            }

        }


        public async static Task SeedClaimsForSuperAdminAsync(this RoleManager<IdentityRole> roleManager)
        {

            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "StockItems");

        }
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
            };
        }





    }

}
