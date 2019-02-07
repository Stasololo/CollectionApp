using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class CashCentre : GenericClass
    {
        public string Name { get; set; }
        public string TimeZone { get; set; }

        [ForeignKey("City")]
        public long CityId { get; set; }
        public City City { get; set; }

        public long? ParentId { get; set; }
        public CashCentre Parent { get; set; }

        public ICollection<ClientTocc> ClientToccs { get; set; }
        public CashCentre()
        {
            ClientToccs = new List<ClientTocc>();
        }
    }
}