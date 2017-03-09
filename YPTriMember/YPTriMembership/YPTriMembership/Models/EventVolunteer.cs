using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class EventVolunteer
    {
        [Key, ForeignKey("Member")]
        [Required]
        [Column(Order = 1)]
        public int MemberId { get; set; }
        public virtual Member VolunteerMember { get; set; }
        public Member Member { get; set; }

        [Key, ForeignKey("Event")]
        [Required]
        [Column(Order = 2)]
        public int EventId { get; set; }
        public virtual Event VolunteerEvent { get; set; }
        public Event Event { get; set; }

        [Required]
        public TimeSpan Hours { get; set; }
    }
}