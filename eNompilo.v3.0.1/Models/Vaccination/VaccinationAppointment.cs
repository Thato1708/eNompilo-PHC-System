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
        [Display(Name = "Have you ever been vaccinated before?")]
        public bool BeenVaccinated { get; set; }

        [Display(Name = "What have you been previously vaccinated for?")]
        public string? PreviousVaccine { get; set; }

        [Required]
        [Display(Name = "Are you pregnant?")]
        public bool IsPregnant { get; set; }

        [Required]
        [Display(Name = "Please seect the disease you are vaccinating for?")]
        public VaccinableDiseases VaccinableDiseases { get; set; }

        [NotMapped]
        public int PractitionerDiaryId { get; set; }
        [NotMapped]
        [ForeignKey("PractitionerDiaryId")]
        public PractitionerDiary PractitionerDiary { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Please choose an available date you'd prefer")]
        public DateTime? PreferredDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: HH:mm}")]
        [DataType(DataType.Time)]
        [Display(Name = "Please choose an available time you'd prefer")]
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
