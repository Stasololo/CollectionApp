using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class CashPointAccountsVM
    {
        public long CashPointId { get; set; }
        public List<long> AccountIds { get; set; }

        public CashPointAccountsVM()
        {
            AccountIds = new List<long>();
        }
    }
}