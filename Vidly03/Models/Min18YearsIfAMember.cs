using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly03.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;

            if (customer.MembershipTypesId == MembershipTypes.Unknown || customer.MembershipTypesId == MembershipTypes.Monthly)
                return ValidationResult.Success;

            if (customer.DateOfBirth == null)
                return new ValidationResult("Birthday is required!");

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("At least 18 years old is required for the membership!");
        }
    }
}