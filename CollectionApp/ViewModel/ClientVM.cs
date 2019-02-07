using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class ClientVM
    {
        public long? Id { get; set; }

        public string Name { get; set; }
        public string BIN { get; set; }
        public string Address { get; set; }
        public string PostIndex { get; set; }
        public string ClisubfmlName { get; set; }
        public string CityName { get; set; }

        public int? ReportGroup1 { get; set; }
        public int? ReportGroup2 { get; set; }
        public int? ReportGroup3 { get; set; }
        public int? ReportGroup4 { get; set; }

        public long? ClisubfmlId { get; set; }
        public long? CityId { get; set; }
    }
}