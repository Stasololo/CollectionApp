using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class Client : GenericClass
    {
        public string Name { get; set; }
        public string BIN { get; set; }
        public string Address { get; set; }
        public string PostIndex { get; set; }

        public int? ReportGroup1 { get; set; }
        public int? ReportGroup2 { get; set; }
        public int? ReportGroup3 { get; set; }
        public int? ReportGroup4 { get; set; }

        [ForeignKey("Clisubfml")]
        public long? ClisubfmlId { get; set; }
        public Clisubfml Clisubfml { get; set; }

        [ForeignKey("City")]
        public long? CityId { get; set; }
        public City City { get; set; }

        public ICollection<ClientTocc> ClientToccs { get; set; }

        public Client()
        {
            ClientToccs = new List<ClientTocc>();
        }
    }
}