using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class DenominationVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime ValidDate { get; set; }

        public long? CurrencyId { get; set; }
    }
}