using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class Member
    {
        [Key]
        [Required]
        public int Member_id { get; set; }

        [Required(ErrorMessage ="A First Name is required.")]
        [StringLength(20)]
        [Display(Name ="First Name")]
        public string First_Name { get; set; }

        [Required(ErrorMessage ="A Last Name is required.")]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "A street address is required!")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Street Address")]
        public string Street_Address { get; set; }

        [Required(ErrorMessage = "A State is required!")]
        [Display(Name = "State")]
        [RegularExpression(@"[A-Z][A-Z]", ErrorMessage ="Please enter a valid state!")]
        public string State_Abr { get; set; }

        [Required(ErrorMessage = "A Zip Code is required!")]
        [Display(Name = "Zip")]
        [RegularExpression(@"^((\d{5}-\d{4})|(\d{5})|([AaBbCcEeGgHhJjKkLlMmNnPpRrSsTtVvXxYy]\d[A-Za-z]\s?\d[A-Za-z]\d))$", ErrorMessage = "Please enter a valid zip code!")]
        public string Zip_Code { get; set; }

        [Phone]
        [Display(Name = "Phone")]
        [StringLength(14)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "An Email is required!")]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage ="Please enter a vaild email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="A gender must be selected.")]
        [Display(Name = "Gender")]
        [StringLength(1)]
        [RegularExpression(@"[MFmf]", ErrorMessage ="Please enter M or F for gender.")]
        public string gender { get; set; }

        [Required(ErrorMessage ="A date of birth must be entered.")]
        [Display(Name = "Date of Birth")]
        public DateTime DoB { get; set; }

        [StringLength(500)]
        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [StringLength(50)]
        [Display(Name = "Employer")]
        public string Employer { get; set; }
        
        public virtual ICollection<Dues_Weak> MemberDues { get; set; }
        public virtual ICollection<Skill> MemberSkills { get; set; }
        public virtual ICollection<Hobby> MemberHobbies { get; set; }
        public virtual ICollection<Event> EventOrganize { get; set; }
        public virtual ICollection<EventVolunteer> MVolunteer { get; set; }

        public Member()
        {
            MemberHobbies = new List<Hobby>();
            EventOrganize = new List<Event>();
            MemberSkills = new List<Skill>();
            MemberDues = new List<Dues_Weak>();


        }
        public int NumberOfSkills
        {
            get
            {
                return MemberSkills.Count;
            }
        }

        public int NumberofHobbies
        {
            get
            {
                return MemberHobbies.Count;
            }
        }
        public int NumberofEventsOrg
        {
            get
            {
                return EventOrganize.Count;
            }
        }
    }
}