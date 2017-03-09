using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }

        [Display(Name = "Title of Hobby")]
        [Required(ErrorMessage = "Title of Hobby is Required")]
        [StringLength(100, ErrorMessage = "Maximum description length is 100 characters.")]
        public string Title { get; set; }

        [Display(Name = "Description of Hobby")]
        [Required(ErrorMessage = "Description of Hobby is Required")]
        [StringLength(1000, ErrorMessage = "Maximum description length is 1000 characters.")]
        public string Description { get; set; }
    }

}