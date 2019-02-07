using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class CashPoint : GenericClass
    {
        public string Name { get; set; }
        public string Address { get; set; }

        [ForeignKey("ClientTocc")]
        public long? ClientToccId { get; set; }
        public ClientTocc ClientTocc { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public CashPoint()
        {
            Accounts = new List<Account>();
        }
    }
}