using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class CashPointAccount
    {
        [ForeignKey("Account")]
        public long? AccountId { get; set; }
        public Account Account { get; set; }

        [ForeignKey("CashPoint")]
        public long? CashPointId { get; set; }
        public CashPoint CashPoint { get; set; }
    }
}