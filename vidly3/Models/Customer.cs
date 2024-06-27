using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly3.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name"), StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        //public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership type")]
        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember, Display(Name = "Date of birth")]
        public DateTime? Birthdate { get; set; }

        public bool IsDelinquent { get; set; }
    }

    public interface ICustomer
    {
        byte MembershipTypeId { get; set; }
        DateTime? Birthdate { get; set; }
    }
}