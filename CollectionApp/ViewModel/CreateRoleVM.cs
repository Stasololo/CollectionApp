using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class CreateRoleVM
    {
        public string Name { get; set; }
        public DateTime Creation { get; set; }
        public int LastUpdateUser { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}