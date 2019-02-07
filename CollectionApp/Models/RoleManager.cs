using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    class RoleManager : RoleManager<Role>
    {
        public RoleManager(RoleStore<Role> store)
                    : base(store)
        { }
        public static RoleManager Create(IdentityFactoryOptions<RoleManager> options,
                                                IOwinContext context)
        {
            return new RoleManager(new
                    RoleStore<Role>(context.Get<ApplicationDbContext>()));
        }
    }
}