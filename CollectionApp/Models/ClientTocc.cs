using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class ClientTocc : GenericClass
    {
        [ForeignKey("Client")]
        public long ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("CashCentre")]
        public long CashCentreId { get; set; }
        public CashCentre CashCentre { get; set; }

        public ICollection<CashPoint> CashPoints { get; set; }
        public ICollection<Account> Accounts { get; set; }

        public ClientTocc()
        {
            CashPoints = new List<CashPoint>();
            Accounts = new List<Account>();
        }
    }
}