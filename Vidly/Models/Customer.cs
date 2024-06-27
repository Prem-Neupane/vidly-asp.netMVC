using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        //data annotation attribute //ovverriding default conventions
        [Required ]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; } //navigation property //to load the object

        public DateTime? Birthdate { get; set; }

        //[ForeignKey("MembershipType")]
        public byte MembershipTypeId { get; set; }
    }


}