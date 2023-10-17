using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.GBV
{
    public class SupportMembership
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Please enter your first name: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Please enter your surname: ")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Enter your Cell Phone number: ")]
        public int Cell{get;set;}

        [Display(Name = "Enter your Email Address: ")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Enter your gender: ")]
        public string gender { get; set; }

        [Required]
        [Display(Name = "Have you ever Reported GBV: ")]
        public bool Reported { get; set; }

    }
}
