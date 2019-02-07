using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class EditUserVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public string Code { get; set; }
        public string Reference { get; set; }
        public DateTime ExpireDate { get; set; }

        public long? CashCentreId { get; set; }
    }
}