using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class CurrencyVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CurrCode { get; set; }

        //public float? Rate { get; set; }
        public float SellRate { get; set; }

        public bool? Locked { get; set; }
    }
}