using CollectionApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class CreateUserVM
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }
       
        public string Code { get; set; }
        public string Reference { get; set; }
        public DateTime ExpireDate { get; set; }

        
        public string RoleId { get; set; }
        public List<string> SelectedRoleIds { get; set; }
        public string SelectedRoleNameStr { get; set; }

        public long CashCentreId { get; set; }
        public string CashCentreName { get; set; }
    }
}