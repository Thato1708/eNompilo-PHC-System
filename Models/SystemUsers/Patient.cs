using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using eNompilo.v3._0._1.Constants;

namespace eNompilo.v3._0._1.Models.SystemUsers
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser Users { get; set; }


        [Required]
        [PersonalData]
        [Display(Name = "ID Number")]
        [StringLength(13, ErrorMessage = "The {0} must strictly be {1} characters long.", MinimumLength = 13)]
        public string IdNumber { get; set; }

        [Required]
        public Titles Titles { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "First Name")]
        [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
        public string? MiddleName { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Last Name")]
        [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [PersonalData]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Phone Number")]
        [StringLength(10, ErrorMessage = "Standard phone number can only be 10 digits long.", MinimumLength = 10)] //datatype must be number in view/html
        public string PhoneNumber { get; set; }

        //      [Required]
        //      public int PersonalDetailsId { get; set; }
        //[ForeignKey("PersonalDetailsId")]
        //public PersonalDetails PersonalDetails { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool Archived { get; set; } = false;
    }
}
