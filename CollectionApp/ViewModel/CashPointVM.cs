using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class CashPointVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public long? CashCentreId { get; set; }

        public List<long> SelectedAccountIds { get; set; }
        public string SelectedAccountNamesStr { get; set; }
        public ICollection<Account> Accounts { get; set; }

        public ClientTocc ClientTocc { get; set; }
        public long? ClientToccId { get; set; }
    }
}