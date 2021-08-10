using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly03.Models;

namespace Vidly03.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the customer's name!")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubcribedToNewsletter { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        public byte MembershipTypesId { get; set; }
        public MembershipTypeDto MembershipTypes { get; set; }
    }
}