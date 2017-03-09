namespace YPTriMembership.DataContexts.MembershipMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<YPTriMembership.DataContexts.MembershipDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DataContexts\MembershipMigrations";
        }

        protected override void Seed(YPTriMembership.DataContexts.MembershipDb context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "SuperUser"))
            {
                roleManager.Create(new IdentityRole { Name = "SuperUser" });
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "superuser@admin.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "superuser@admin.com",
                    UserName = "superuser@admin.com"
                };
                userManager.Create(user, "Pass123!");
                userManager.AddToRole(user.Id, "SuperUser");
            }

        }
    }
}
