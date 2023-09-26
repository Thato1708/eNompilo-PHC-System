using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using eNompilo.v3._0._1.Constants;

namespace eNompilo.v3._0._1.Models.SystemUsers
{
    public class PersonalDetails
    {
        [Key]
        public int Id { get; set; }

        [PersonalData]
        [Display(Name = "Profile Picture")]
        public string? ProfilePicture { get; set; }

        [NotMapped]
        [Display(Name = "Upload Profile Image")]
        public IFormFile? ProfilePictureImageFile { get; set; }

        [Required]
        [PersonalData]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Please select who referred you to us.")]
        public HearFromUs Referrer { get; set; }

        [Required]
        [PersonalData]
        public Gender Gender { get; set; }

        [Required]
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

        [Required]
        [PersonalData]
        [Display(Name = "Emergency Contact Person (Full Name)")]
        public string EmergencyPerson { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Emergency Contact Number")]
        [StringLength(10, ErrorMessage = "Standard phone number can only be 10 digits long.", MinimumLength = 10)]
        public string EmergenyContactNr { get; set; }

        [Required]
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
        [Required]
        public Citizenship Citizenship { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Marital Status")]
        public MaritalStatus MaritalStatus { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [PersonalData]
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [PersonalData]
        [Display(Name = "Suburb")]
        public string? Suburb { get; set; }

        [Required]
        [PersonalData]
        public string City { get; set; }

        [Required]
        [PersonalData]
        public Provinces Province { get; set; }

        [Required]
        [PersonalData]
        public string ZipCode { get; set; }

        //public int MedicalHistoryId { get; set; }
        //[ForeignKey("MedicalHistoryId")]
        //[PersonalData]
        //public MedicalHistory MedicalHistory { get; set; }

        [Required]
        public bool Archived { get; set; } = false;
        public virtual Patient Patient { get; set; }
    }
}
