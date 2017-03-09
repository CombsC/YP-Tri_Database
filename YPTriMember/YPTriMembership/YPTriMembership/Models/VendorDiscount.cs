using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class VendorDiscount
    {
        [Key]
        [Column(Order = 0)]
        [Display(Name = "Vendor Discount ID")]
        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor DiscountVendor { get; set; }
        public Vendor Vendor { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Event Discount ID")]
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public virtual Event DiscountEvent { get; set; }
        public Event Event { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Vendor Discount Description")]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Display(Name = "Vendor Discount Value")]
        public string Value { get; set; }
    }
}