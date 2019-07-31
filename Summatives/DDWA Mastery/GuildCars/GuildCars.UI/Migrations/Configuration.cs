namespace GuildCars.UI.Migrations
{
    using GuildCars.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GuildCars.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var store = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(store);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var sales = new IdentityRole { Name = "Sales" };
            var disabled = new IdentityRole { Name = "Disabled" };
            var admin = new IdentityRole { Name = "Admin" };
            roleManager.Create(admin);
            roleManager.Create(sales);
            roleManager.Create(disabled);
            if (!context.Users.Any(u => u.UserName == "admin@test.com"))
            {
                var adminUser = new ApplicationUser()
                {
                    UserName = "admin@test.com",
                    isEnabled = true,
                    firstName = "Joshua",
                    lastName = "Wakefield",
                    roleId = "Admin",
                    Email = "admin@test.com"
                };
                var salesUser = new ApplicationUser()
                {
                    UserName = "sales@test.com",
                    isEnabled = true,
                    firstName = "Debbie",
                    lastName = "Keene",
                    roleId = "Sales",
                    Email = "sales@test.com"
                };
                userManager.Create(adminUser, "Testing1!");
                userManager.AddToRole(adminUser.Id, "Admin");
                userManager.Create(salesUser, "Testing1!");
                userManager.AddToRole(salesUser.Id, "Sales");
            }
        }
    }
}
