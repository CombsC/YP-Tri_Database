using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class SponsorGift
    {
        [Key, ForeignKey("Event")]
        [Required]
        [Column(Order = 1)]
        [Display(Name = "Event Gift")]
        public int? Eventid { get; set; }
        public virtual Event GiftEvent { get; set; }
        public Event Event { get; set; }

        [Key, ForeignKey("Sponsor")]
        [Required]
        [Column(Order = 2)]
        [Display(Name = "Gift Sponsor")]
        public int? Sponsorid { get; set; }
        public virtual Sponsor GiftSponsor { get; set; }
        public Sponsor Sponsor { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Sponsor Description")]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Gift Value")]
        public Decimal Gift_Value { get; set; }
    }
}