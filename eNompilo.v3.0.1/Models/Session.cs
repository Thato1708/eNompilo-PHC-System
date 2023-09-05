using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Models.Vaccination;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public int? PractitionerId { get; set; }
        [ForeignKey("PractitionerId")]
        public Practitioner Practitioner { get; set; }

        [NotMapped]
        public int VaccinationAppointmentId { get; set; }
        [ForeignKey("VaccinationAppointmentId")]
        [NotMapped]
        public VaccinationAppointment VaccinationAppointment { get; set; }

        [NotMapped]
        public int CounsellingAppointmentId { get; set; }
        [ForeignKey("CounsellingAppointmentId")]
        [NotMapped]
        public CounsellingAppointment CounsellingAppointment { get; set; }

        [NotMapped]
        public int GeneralAppointmentId { get; set; }
        [ForeignKey("GeneralAppointmentId")]
        [NotMapped]
        public GeneralAppointment GeneralAppointment { get; set; }

        [Required]
        [Display(Name = "Did patient arrive for session?")]
        public bool Arrived { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: HH:mm}")]
        [DataType(DataType.Time)]
        [Display(Name = "Patient arrival time")]
        public DateTime? ArrivalTime { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: HH:mm}")]
        [DataType(DataType.Time)]
        [Display(Name = "Session end time")]
        public DateTime? EndTime { get; set; }

        public int SessionNotesId { get; set; }
        [ForeignKey("SessionNotesId")]
        public SessionNotes? SessionNotes { get; set; }

        [Required]
        public bool Archived { get; set; }

    }
}
