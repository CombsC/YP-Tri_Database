using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class Sponsor
    {
        [Required]
        [Key]
        [Display(Name = "Sponsor ID")]
        public int Sponsor_id { get; set; }

        [Required(ErrorMessage ="A name must be entered for a Sponsor.")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Sponsor Name")]
        public string Company_Name { get; set; }

        [Required(ErrorMessage ="A phone number is required for a Sponsor.")]
        [Phone]
        [Display(Name = "Phone")]
        [StringLength(14)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "A street address is required!")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Street Address")]
        public string Street_Address { get; set; }

        [Required(ErrorMessage = "A State is required!")]
        [Display(Name = "State")]
        [StringLength(2)]
        [RegularExpression(@"[A-Z][A-Z]", ErrorMessage = "Invalid State Abbr!")]
        public string State_Abr { get; set; }

        [Required(ErrorMessage = "A Zip Code is required!")]
        [Display(Name = "Zip")]
        [RegularExpression(@"^((\d{5}-\d{4})|(\d{5})|([AaBbCcEeGgHhJjKkLlMmNnPpRrSsTtVvXxYy]\d[A-Za-z]\s?\d[A-Za-z]\d))$", ErrorMessage = "Please enter a valid zip code!")]
        public string Zip_Code { get; set; }

        [Required(ErrorMessage ="An email is required for a Sponsor.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<SponsorGift> SponsorGifts { get; set; }

        public Sponsor()
        {
            Events = new List<Event>();
            SponsorGifts = new List<SponsorGift>();
        }

        public int NumberOfEvents
        {
            get
            {
                return Events.Count;
            }
        }
        public int NumberofSponsorGifts
        {
            get
            {
                return SponsorGifts.Count;
            }
        }

    }
}