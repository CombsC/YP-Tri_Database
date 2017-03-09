using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class Dues_Weak
    {
        
        [Key]
        [Required]
        [Column(Order =0)]
        [Display(Name = "Dues ID")]
        public int Dues_id { get; set; }

        [Key, ForeignKey("Member")]
        [Required]
        [Column(Order =1)]
        public int Member_id { get; set; }
        public virtual Member Member_Dues { get; set; }
        public Member Member { get; set; }
               
        [Required]
        [Display(Name = "Date of Dues Paid")]
        public DateTime Date_Of_Payment { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Amount Dues Paid")]
        public Decimal Amount_Paid { get; set; }

        [Required]
        [Display(Name = "Membership Expiration Date")]
        public DateTime Membership_Exp { get; set; }

    }

}