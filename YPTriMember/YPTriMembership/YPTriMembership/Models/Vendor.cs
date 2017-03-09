using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class Vendor
    {
        [Key]
        [Required]
        [Display(Name = "Vendor ID")]
        public int Vendor_id { get; set; }

        [Required(ErrorMessage ="A name must be entered")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Vendor Name")]
        public string Company_Name { get; set; }

        [Phone]
        [Required(ErrorMessage ="A Phone number is required for a Vendor")]
        [StringLength(14)]
        [Display(Name = "Phone")]
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

        [Required(ErrorMessage ="An Email is required for a Vendor!")]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(30, MinimumLength = 1)]
        public string Email { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public Vendor()
        {
            Events = new List<Event>();
        }

        public int NumberofEventsSponsored
        {
            get
            {
                return Events.Count;
            }
        }
    }
}