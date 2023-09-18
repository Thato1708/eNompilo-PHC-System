using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace eNompilo.v3._0._1.Models.ViewModels
{
    public class EditUserViewModel:IdentityUser
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "ID Number")]
        [StringLength(13, ErrorMessage = "The {0} must strictly be {1} characters long.", MinimumLength = 13)]
        public string IdNumber { get; set; }

        [Required]
        public Titles Titles { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [PersonalData]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public override string? Email { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Phone Number")]
        [StringLength(10, ErrorMessage = "Standard phone number can only be 10 digits long.", MinimumLength = 10)] //datatype must be number in view/html
        public override string PhoneNumber { get; set; }

        public bool Archived { get; set; }

        public Patient Patient { get; set; }
    }
}
