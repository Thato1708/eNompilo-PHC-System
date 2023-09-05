using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Models.Vaccination;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models
{
    public class PractitionerDiary
    {
        [Key]
        public int Id { get; set; }

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: HH:mm}")]
        [DataType(DataType.Time)]
        [Display(Name = "Appointment Start Time")]
        public DateTime? StartTime { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: HH:mm}")]
        [DataType(DataType.Time)]
        [Display(Name = "Appointment End Time")]
        public DateTime? EndTime { get; set; }
        [Required]
        public int PractitionerId { get; set; }
        [ForeignKey("PractitionerId")]
        public Practitioner Practitioner { get; set; }
        public bool Archived { get; set; }
    }
}
