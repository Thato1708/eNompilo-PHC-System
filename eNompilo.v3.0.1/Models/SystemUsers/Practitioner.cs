using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace eNompilo.v3._0._1.Models.SystemUsers
{
    public class Practitioner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [PersonalData]
        [Display(Name = "Profile Picture")]
        public string? ProfilePicture { get; set; }

        [NotMapped]
        [Display(Name = "Upload Profile Picture")]
        public IFormFile? ProfilePictureImageFile { get; set; }

        [Display(Name = "Practitioner Type")]
        public PractitionerType? PractitionerType { get; set; }

        [Display(Name = "Counsellor Type")]
        public CounsellorType? CounsellorType { get; set; }

        [PersonalData]
        public Gender? Gender { get; set; }

        [PersonalData]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

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
        [Display(Name = "Work Telephone")]
        public string? WorkTel { get; set; }

        [PersonalData]
        [Display(Name = "Work Email")]
        public string? WorkEmail { get; set; }

        [PersonalData]
        [Display(Name = "Line Manager")]
        public string? LineManager { get; set; }

        [PersonalData]
        public Citizenship? Citizenship { get; set; }

        [PersonalData]
        [Display(Name = "Marital Status")]
        public MaritalStatus? MaritalStatus { get; set; }

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
        public Provinces? Province { get; set; }

        [PersonalData]
        public string? ZipCode { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public bool Archived { get; set; }
        public virtual ApplicationUser? Users { get; set; }
    }
}
