using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.ViewModels
{
	public class UserTypeViewModel
	{
		public string? Id { get; set; }

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

		[Display(Name = "Middle Name")]
		[StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
		public string? MiddleName { get; set; }

		[Required]
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

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Date Created On")]
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		[Display(Name = "User Role")]
		public UserRole UserRole { get; set; }

		public DateTime LastLogin { get; set; }

		public bool Archived { get; set; }

        public virtual ApplicationUser? AppUser { get; set; }
		public virtual Patient? Patient { get; set; }
        public virtual PersonalDetails? PersonalDetails { get; set; }
        public virtual MedicalHistory? MedicalHistory { get; set; }
        public virtual Practitioner? Practitioner { get; set; }
		public virtual Admin? Admin { get; set; }
		public virtual Receptionist? Receptionist { get; set; }
    }
}
