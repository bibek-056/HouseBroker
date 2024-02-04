using Microsoft.AspNetCore.Identity;
using HouseBroker.Core;

namespace HouseBroker.Infrastructure.Data
{
    public class DataInitializer
    {
        public async Task RoleInitializer(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { UserRoles.HouseBroker, UserRoles.HouseSeeker };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
