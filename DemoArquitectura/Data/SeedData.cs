using DemoArquitectura.Data;
using DemoArquitectura.Web.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoArquitectura.Web.Data
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var context = provider.GetRequiredService<ApplicationDbContext>();
                var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

                // automigration 
                context.Database.Migrate();
                InstallUsers(userManager, roleManager);
            }
        }

        private static void InstallUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string USERNAME = "gustavo.reyes@qacg.com";
            const string PASSWORD = @"m,D:G8_NJV.+hjts=b6R";
            const string ROLENAME = "Clients";

            var roleExist = roleManager.RoleExistsAsync(ROLENAME).Result;
            if (!roleExist)
            {
                //create the roles and seed them to the database
                roleManager.CreateAsync(new IdentityRole(ROLENAME)).GetAwaiter().GetResult();
            }

            var user = userManager.FindByNameAsync(USERNAME).Result;

            if (user == null)
            {
                var serviceUser = new ApplicationUser
                {
                    UserName = USERNAME,
                    Email = USERNAME,
                    Age = 18,
                    Department = "BIP"
                };

                var createPowerUser = userManager.CreateAsync(serviceUser, PASSWORD).Result;
                if (createPowerUser.Succeeded)
                {
                    var confirmationToken = userManager.GenerateEmailConfirmationTokenAsync(serviceUser).Result;
                    var result = userManager.ConfirmEmailAsync(serviceUser, confirmationToken).Result;
                    //here we tie the new user to the role
                    userManager.AddToRoleAsync(serviceUser, ROLENAME).GetAwaiter().GetResult();
                }
            }
        }

    }
}
