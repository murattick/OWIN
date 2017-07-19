using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cook.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var AdminRole = new IdentityRole { Name = "Administrator" };
            var UserRole = new IdentityRole { Name = "User" };

            // добавляем роли в бд
            roleManager.Create(AdminRole);
            roleManager.Create(UserRole);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "murattick@gmail.com", UserName = "murattick@gmail.com" };
            string password = "Kbxuwg1ufig!";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, AdminRole.Name);
                userManager.AddToRole(admin.Id, UserRole.Name);
            }

            base.Seed(context);
        }
    }
}