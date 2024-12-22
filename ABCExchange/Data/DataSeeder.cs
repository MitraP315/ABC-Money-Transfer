using ABCExchange.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoneyTransferProjec.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

public class DataSeeder
{
    public static async Task SeedSuperAdminAsync(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        // Check if already seeded
        var seedStatus = await dbContext.Set<SeedStatus>().FirstOrDefaultAsync();
        if (seedStatus?.IsSeeded == true)
            return;

        // Seed roles and SuperAdmin
        var superAdminRole = "SuperAdmin";
        var superAdminEmail = "superadmin@example.com";
        var superAdminPassword = "SuperSecurePassword123!";

        if (!await roleManager.RoleExistsAsync(superAdminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(superAdminRole));
        }

        var superAdminUser = await userManager.FindByEmailAsync(superAdminEmail);
        if (superAdminUser == null)
        {
            superAdminUser = new IdentityUser
            {
                UserName = superAdminEmail,
                Email = superAdminEmail,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(superAdminUser, superAdminPassword);
            await userManager.AddToRoleAsync(superAdminUser, superAdminRole);
        }

        // Mark as seeded
        if (seedStatus == null)
        {
            dbContext.Set<SeedStatus>().Add(new SeedStatus { IsSeeded = true, LastSeededOn = DateTime.UtcNow });
        }
        else
        {
            seedStatus.IsSeeded = true;
            seedStatus.LastSeededOn = DateTime.UtcNow;
        }

        await dbContext.SaveChangesAsync();
    }
   
}
