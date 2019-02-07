using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class Role : IdentityRole
    {
        public Role() : base()
        {
        }

        public Role(string roleName) : base(roleName)
        {
        }

        public DateTime Creation { get; set; }
        public string LastUpdateUser { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}