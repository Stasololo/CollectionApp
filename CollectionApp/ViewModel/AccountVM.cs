using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class AccountVM
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long? CurrencyId { get; set; }
        public string CurrencyName { get; set; }

        public long? ClientId { get; set; }
        public string ClientName { get; set; }

        public List<long> SelectedCashPointIds { get; set; }
        public string SelectedCashPointNamesStr { get; set; }
    }
}