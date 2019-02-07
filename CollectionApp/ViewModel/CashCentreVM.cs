using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectionApp.ViewModel
{
    public class CashCentreVM
    {
        public long Id { get; set; }
        public string TimeZone { get; set; }
        public string Name { get; set; }

        public long CityId { get; set; }
        public string CityName { get; set; }

        public long? ParentId { get; set; }
        public string ParentName { get; set; }

        public long ClientId { get; set; }
        public string SelectedClientNamesStr { get; set; }

        public long? CashPoint { get; set; }
        public string SelectedCashPointNamesStr { get; set; }

        public List<long> SelectedClientIds { get; set; }
        public List<long> SelectedCashPointIds { get; set; }
    }
}