using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eNompilo.v3._0._1.Models.ViewModels
{
    public class PractitionerIndexViewModel
    {

        [ForeignKey("User")]
        public string? UserId { get; set; }

        [ForeignKey("Receptionist")]
        public string? ReceptionistId { get; set; }

        public Titles? Titles { get; set; }

        [Display(Name = "First Name")]
        [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
        public string? LastName { get; set; }

        [PersonalData]
        [Display(Name = "Email Address")]
        [EmailAddress]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter correct email format (username@domain.ext.cde)")]
        public string? Email { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Phone Number")]
        [StringLength(10, ErrorMessage = "Standard phone number can only be 10 digits long.", MinimumLength = 10)] //datatype must be number in view/html
        [RegularExpression(@"^((?:\+27|27)|0)(=|60|70|80|61|71|81|62|72|82|63|73|83|64|74|84|65|75|85|66|76|86|67|77|87|68|78|88|69|79|89)(\d{7})$", ErrorMessage = "Please enter a South African number.")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Practitioner Type")]
        public PractitionerType? PractitionerType { get; set; }

        [Display(Name = "Counsellor Type")]
        public CounsellorType? CounsellorType { get; set; }

        [PersonalData]
        [Display(Name = "Line Manager")]
        public string? LineManager { get; set; }

        [PersonalData]
        [Display(Name = "Address Line 1")]
        public string? AddressLine1 { get; set; }

        [PersonalData]
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [PersonalData]
        [Display(Name = "Suburb")]
        public string? Suburb { get; set; }

        [PersonalData]
        public string? City { get; set; }
        public virtual ApplicationUser? Users { get; set; }
        public virtual Receptionist? Receptionist { get; set; }
    }

}
