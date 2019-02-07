using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class Denomination : GenericClass
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime ValidDate { get; set; }

        [ForeignKey("Currency")]
        public long? CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}