using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class ClientToccIndexVM
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long? CashPointIds { get; set; }
        public List<long> SelectedCashPointIds { get; set; }
        public string SelectedCashPointNamesStr { get; set; }

        public long? AccountId { get; set; }
        public List<long> SelectedAccountIds { get; set; }
        public string SelectedAccountNamesStr { get; set; }
    }
}