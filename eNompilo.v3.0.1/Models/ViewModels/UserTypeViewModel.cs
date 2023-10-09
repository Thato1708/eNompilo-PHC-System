using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.ViewModels
{
	public class UserTypeViewModel: IdentityUser
	{
        //Foreign Keys
		[ForeignKey("Patient")]
		public int? PatientId { get; set; }

		[ForeignKey("PersonalDetails")]
		public int? PersonalDetailsId { get; set; }

		[ForeignKey("PersonalDetails")]
		public int? MedicalHistoryId { get; set; }

		[ForeignKey("Practitioner")]
		public int? PractitionerId { get; set; }

		[ForeignKey("Receptionist")]
		public int? ReceptionistId { get; set; }

		[ForeignKey("Admin")]
		public int? AdminId { get; set; }

		[ForeignKey("AppUser")]
		public string? Id { get; set; }


        //General App User staff
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

        //Personal Details (Patient (some admin, practitioner and receptionist)
        [PersonalData]
        [Display(Name = "Profile Picture")]
        public string? ProfilePicture { get; set; }

        [NotMapped]
        [Display(Name = "Upload Profile Image")]
        public IFormFile? ProfilePictureImageFile { get; set; }

        [PersonalData]
        public Gender Gender { get; set; }

        [PersonalData]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

        [PersonalData]
        public int? Height { get; set; }

        [PersonalData]
        public int? Weight { get; set; }

        [PersonalData]
        [Display(Name = "Blood Type")]
        public string? BloodType { get; set; }

        [PersonalData]
        [Display(Name = "Home Telephone")]
        public string? HomeTel { get; set; }

        [PersonalData]
        [Display(Name = "Emergency Contact Person (Full Name)")]
        public string? EmergencyPerson { get; set; }

        [PersonalData]
        [Display(Name = "Emergency Contact Number")]
        [StringLength(10, ErrorMessage = "Standard phone number can only be 10 digits long.", MinimumLength = 10)]
        public string? EmergenyContactNr { get; set; }

        [PersonalData]
        [Display(Name = "Employment Status")]
        public bool Employed { get; set; }

        [PersonalData]
        [Display(Name = "Work Telephone")]
        public string? WorkTel { get; set; }

        [PersonalData]
        [Display(Name = "Work Email")]
        public string? WorkEmail { get; set; }

        [PersonalData]
        public Citizenship Citizenship { get; set; }

        [PersonalData]
        [Display(Name = "Marital Status")]
        public MaritalStatus MaritalStatus { get; set; }

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

        [PersonalData]
        public Provinces Province { get; set; }

        [PersonalData]
        public string? ZipCode { get; set; }


        //Additional Admin/Practitioner/Receptionist properties

        [PersonalData]
        [Display(Name = "Line Manager")]
        public string? LineManager { get; set; }

            //Practitioner

        [Display(Name = "Practitioner Type")]
        public PractitionerType? PractitionerType { get; set; }

        [Display(Name = "Counsellor Type")]
        public CounsellorType? CounsellorType { get; set; }

        //Medical History Stuff

        [PersonalData]
        [StringLength(255, ErrorMessage = "You've exceded your maximum number of characters available.")]
        [Display(Name = "Please list conditions have you been previously diagnosed with. If there aren't any, indicate by typing 'None'")]
        public string? PreviousDiagnoses { get; set; }

        [PersonalData]
        [StringLength(255, ErrorMessage = "You've exceded your maximum number of characters available.")]
        [Display(Name = "Please list medication have you been previously prescribed. If there aren't any, indicate by typing 'None'")]
        public string? PreviousMedication { get; set; }

        [PersonalData]
        [StringLength(255, ErrorMessage = "You've exceded your maximum number of characters available.")]
        [Display(Name = "Please list all general allergies you have, that you know off. If there aren't any, indicate by typing 'None'")]
        public string? GeneralAllergies { get; set; }

        [PersonalData]
        [StringLength(255, ErrorMessage = "You've exceded your maximum number of characters available.")]
        [Display(Name = "Please list all allergies to medications that you have and know off. If there aren't any, indicate by typing 'None'")]
        public string? MedicationAllergies { get; set; }


        public virtual PersonalDetails? PersonalDetails { get; set; }
        public virtual MedicalHistory? MedicalHistory { get; set; }
        public virtual Practitioner? Practitioner { get; set; }
		public virtual Admin? Admin { get; set; }
		public virtual Receptionist? Receptionist { get; set; }
    }
}
