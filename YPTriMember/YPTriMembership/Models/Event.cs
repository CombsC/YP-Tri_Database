using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class Event
    {
        [Key]
        [Required]
        [Display(Name = "Event id")]
        public int Event_id { get; set; }

        [Required(ErrorMessage ="An Event Title is required!")]
        [Display(Name = "Event Title")]
        [StringLength(50)]
        public string Title { get; set; }


        [Required(ErrorMessage = "A street address is required!")]
        [Display(Name = "Street Address")]
        [StringLength(20)]
        public string Street_Address { get; set; }

        [Required(ErrorMessage = "A State is required!")]
        [Display(Name = "State")]
        [RegularExpression(@"[A-Z][A-Z]", ErrorMessage = "Invalid State Abbr!")]
        public string State_Abr { get; set; }

        [Required(ErrorMessage = "A Zip Code is required!")]
        [Display(Name = "Zip")]
        [RegularExpression(@"^((\d{5}-\d{4})|(\d{5})|([AaBbCcEeGgHhJjKkLlMmNnPpRrSsTtVvXxYy]\d[A-Za-z]\s?\d[A-Za-z]\d))$", ErrorMessage ="Please enter a valid zip code!")]
        public string Zip_Code { get; set; }

        [Required(ErrorMessage = "A Date and Time is required!")]
        [Display(Name = "Date and Time")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "An Event Description is required!")]
        [StringLength(300)]
        [Display(Name = "Event Description")]
        public string Description { get; set; }

         [Required(ErrorMessage ="A member organizer must be selected!")]
         [Display(Name = "Event Organizer")]
         [ForeignKey("Member")]
         [Column(Order = 0)]
         public int Member_Number { get; set; }       
         public virtual Member MemberOrganizer { get; set; }
         public Member Member { get; set; }
    

        public virtual ICollection<SponsorGift> ESponsorGift { get; set; }
        public virtual ICollection<EventVolunteer> EVolunteer { get; set; }
        public virtual ICollection<VendorDiscount> EDiscount { get; set; }

        public Event()
        {
            ESponsorGift = new List<SponsorGift>();
            EVolunteer = new List<EventVolunteer>();
            EDiscount = new List<VendorDiscount>();
        }

        public int NumberofSponsorGifts
        {
            get
            {
                return ESponsorGift.Count;
            }
        }
        public int NumberOfEventVolunteers
        {
            get
            {
                return EVolunteer.Count;
            }
        }
        public int NumberOfVendorDiscounts
        {
            get
            {
                return EDiscount.Count;
            }
        }

        
    }
}