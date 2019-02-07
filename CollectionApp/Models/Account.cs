using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class Account : GenericClass
    {
        public string Name { get; set; }

        [ForeignKey("Currency")]
        public long? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [ForeignKey("ClientTocc")]
        public long? ClientToccId { get; set; }
        public ClientTocc ClientTocc { get; set; }

        //[ForeignKey("CashPoint")]
        //public long? CashPointId { get; set; }
        //public CashPoint CashPoint { get; set; }
        
        [ForeignKey("Client")]
        public long? ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<CashPoint> CashPoints { get; set; }

        public Account()
        {
            CashPoints = new List<CashPoint>();
        }
    }
}