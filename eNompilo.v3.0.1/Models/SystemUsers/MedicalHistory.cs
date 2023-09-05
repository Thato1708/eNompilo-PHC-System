using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.SystemUsers
{
    public class MedicalHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [PersonalData]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Required]
        [PersonalData]
        [StringLength(255, ErrorMessage = "You've exceded your maximum number of characters available.")]
        [Display(Name = "Please list conditions have you been previously diagnosed with. If there aren't any, indicate by typing 'None'")]
        public string PreviousDiagnoses { get; set; }

        [Required]
        [PersonalData]
        [StringLength(255, ErrorMessage = "You've exceded your maximum number of characters available.")]
        [Display(Name = "Please list medication have you been previously prescribed. If there aren't any, indicate by typing 'None'")]
        public string PreviousMedication { get; set; }

        [Required]
        [PersonalData]
        [StringLength(255, ErrorMessage = "You've exceded your maximum number of characters available.")]
        [Display(Name = "Please list all general allergies you have, that you know off. If there aren't any, indicate by typing 'None'")]
        public string GeneralAllergies { get; set; }

        [Required]
        [PersonalData]
        [StringLength(255, ErrorMessage = "You've exceded your maximum number of characters available.")]
        [Display(Name = "Please list all allergies to medications that you have and know off. If there aren't any, indicate by typing 'None'")]
        public string MedicationAllergies { get; set; }
    }
}
