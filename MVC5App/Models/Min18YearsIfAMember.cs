using System;
using System.Activities.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MemberShipTypeId == 0 || customer.MemberShipTypeId == 1)
                return ValidationResult.Success;
            if (customer.DateOfBirth == null)
                return new ValidationResult("BDO is required");
            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success 
                : new ValidationResult("Membership should be at least 18 years old");
        }
    }
}