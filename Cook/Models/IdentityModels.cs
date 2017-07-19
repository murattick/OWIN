using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cook.Models
{

            

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // добавляем нужные нам свойства к user
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Otchestvo { get; set; }
        public int Year { get; set; }
        public string Region { get; set; }
        public string Sity { get; set; }
        public string Address { get; set; }
        public int PostStage { get; set; }
        public byte[] MyPhoto { get; set; }
        public string MIMEType { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    // добавляем модель Запросов пользователей
    public class UserQuery
    {
        [Key]
        public Guid QueryId { get; set; }
        public string QueryName { get; set; }
        public string QueryDiscription { get; set; }
        public string CreateUserName { get; set; }
        public string ChangeUserName { get; set; }
        public string Status { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int IngredientsId { get; set; }
        public int IngredientsCategoryId { get; set; }
        public int IngredientsSubcategoryId { get; set; }
        public byte[] Photo { get; set; }
        public string MIMEType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDateTime { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //подключение таблицы запросов пользователей
        public DbSet<UserQuery> UsersQuery { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<Cook.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}