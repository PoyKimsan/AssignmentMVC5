using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Please Enter Cutomer Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name="Subscribe To Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Min18YearsIfAMember]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name="MemberShip Type")]
        public byte MemberShipTypeId { get; set; }
    }
}