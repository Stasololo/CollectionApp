using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class Clisubfml : GenericClass
    {
        public string Name { get; set; }
        public ICollection<Client> ClientGroup { get; set; }
    }
}