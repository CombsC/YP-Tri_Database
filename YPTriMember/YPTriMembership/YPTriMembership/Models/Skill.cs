using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YPTriMembership.Models
{
    public class Skill
    {
        [Key]
        [Required]
        public int SkillId { get; set; }

        [Display(Name = "Title of Skill")]
        [Required(ErrorMessage = "Title of Skill is Required")]
        public string Title { get; set; }


        [Display(Name = "Description of Skill")]
        [Required(ErrorMessage = "Description of Skill is Required")]
        public string Description { get; set; }

    }
}