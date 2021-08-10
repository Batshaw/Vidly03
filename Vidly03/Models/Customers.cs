using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly03.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the customer's name!")]
        [StringLength(255)]
        [Display(Name = "Fullname")]
        public string Name { get; set; }

        public bool IsSubcribedToNewsletter { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        public MembershipTypes MembershipTypes { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypesId { get; set; }
    }
}