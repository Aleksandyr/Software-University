using System.Collections.Generic;
using Events.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Events.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class DbMigrationsConfig : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Events.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var adminEmail = "admin@admin.com";
                var adminUserName = adminEmail;
                var adminFullName = "System Administrator";
                var adminPassword = adminEmail;
                string adminRole = "Administrator";
                CreateAdminUser(context, adminEmail, adminUserName, adminPassword, adminRole);
                CreateSeveralEvents(context);
            }

        }

        private void CreateAdminUser(ApplicationDbContext context, string adminEmail, 
            string adminUserName, string adminPassword, string adminRole)
        {
            var adminUser = new ApplicationUser()
            {
                UserName = adminUserName,
                Email = adminEmail
            };

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            userManager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var userCreateResult = userManager.Create(adminUser, adminPassword);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(String.Join("; ", userCreateResult.Errors));
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(adminRole));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(String.Join("; ", roleCreateResult.Errors));
            }

            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, adminRole);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(String.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreateSeveralEvents(ApplicationDbContext context)
        {
            context.Events.Add(new Event()
            {
                Title = "Party @ SofUni",
                StartDateTime = DateTime.Now.Date.AddDays(5).AddHours(2).AddMinutes(30),
                Author = context.Users.First(),
            });

            context.Events.Add(new Event()
            {
                Title = "Passed Event <Anonymous>",
                StartDateTime = DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(30),
                Duration = TimeSpan.FromHours(1.5),
                Comments = new HashSet<Comment>()
                {
                    new Comment() { Text = "<Anonymous> comment" },
                    new Comment() { Text = "User comment", Author = context.Users.First() },
                }
            });
        }
    }
}
