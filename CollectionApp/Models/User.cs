using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CollectionApp.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. 
    //Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class User : IdentityUser
    {
        public User() : base()
        {

        }

        public User(string userName) : base(userName)
        {

        }

        public DateTime Creation { get; set; }
        public string LastUpdateUser { get; set; }
        public DateTime LastUpdate { get; set; }

        public string Code { get; set; }
        public string Reference { get; set; }
        public DateTime ExpireDate { get; set; }

        [ForeignKey("CashCentre")]
        public long? CashCentreId { get; set; }
        public CashCentre CashCentre { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, 
            // определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }
}