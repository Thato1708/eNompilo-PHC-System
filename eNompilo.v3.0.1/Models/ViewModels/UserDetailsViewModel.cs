using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eNompilo.v3._0._1.Models.ViewModels
{
	public class UserDetailsViewModel
	{
		[Required]
		public string Id { get; set; }
		
		[Display(Name = "ID Number")]
		[StringLength(13, ErrorMessage = "The {0} must strictly be {1} characters long.", MinimumLength = 13)]
		public string IdNumber { get; set; }

		public Titles Titles { get; set; }

		[Display(Name = "First Name")]
		[StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
		public string FirstName { get; set; }

		[Display(Name = "Middle Name")]
		[StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
		public string MiddleName { get; set; }

		[Display(Name = "Last Name")]
		[StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
		public string LastName { get; set; }

		[PersonalData]
		[Display(Name = "Email Address")]
		[EmailAddress]
		public string? Email { get; set; }

		[PersonalData]
		[Display(Name = "Phone Number")]
		[StringLength(10, ErrorMessage = "Standard phone number can only be 10 digits long.", MinimumLength = 10)] //datatype must be number in view/html
		public string PhoneNumber { get; set; }

		[Display(Name = "User Role")]
		public UserRole UserRole { get; set; }

		[Display(Name = "Date Created On")]
        public DateTime CreatedOn { get; set; }

        public bool Archived { get; set; }

		public Patient Patient { get; set; }

		public virtual ApplicationUser ApplicationUser { get; set; }

	}
}
