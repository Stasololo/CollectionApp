using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class ClientToccVM
    {
        public long Id { get; set; }

        public long ClientId { get; set; }
        public long CashCentreId { get; set; }

        public List<long> SelectedCashPointIds { get; set; }
        public string SelectedCashPointtNamesStr { get; set; }

        public List<long> SelectedAccountIds { get; set; }
        public string SelectedAccountNamesStr { get; set; }
    }
}