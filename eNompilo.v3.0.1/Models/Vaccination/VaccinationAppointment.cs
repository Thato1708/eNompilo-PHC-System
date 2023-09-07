using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Vaccination
{
    public class VaccinationAppointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Vaccinated Before?")]
        public bool BeenVaccinated { get; set; }

        [Display(Name = "Vaccinated for what previously?")]
        public string? PreviousVaccine { get; set; }

        [Required]
        [Display(Name = "Are you pregnant?")]
        public bool IsPregnant { get; set; }

        [Required]
        [Display(Name = "Disease vaccinating for.")]
        public VaccinableDiseases VaccinableDiseases { get; set; }

        [NotMapped]
        public int PractitionerDiaryId { get; set; }
        [NotMapped]
        [ForeignKey("PractitionerDiaryId")]
        public PractitionerDiary PractitionerDiary { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public DateTime? PreferredDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: HH:mm}")]
        [DataType(DataType.Time)]
        [Display(Name = "Preffered Time")]
        public DateTime? PreferredTime { get; set; }

        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Required]
        public int PatientFileId { get; set; }
        [ForeignKey("PatientFileId")]
        public PatientFile PatientFile { get; set; }

        [Required]
        public bool Archived { get; set; }
    }
}
