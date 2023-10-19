using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Family_Planning
{
    public class FamilyPlanningAppointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Booking Reason")]
        public BookingReasons BookingReasons { get; set; }

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
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("Practitioner")]
        public int? PractitionerId { get; set; }

        [Required]
        public bool SessionConfirmed { get; set; } = false;
        public bool? IsCollected { get; set; }
        [Required]
        public bool Archived { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual Practitioner? Practitioner { get; set; }
        public string? ResponsiblePractitionerId { get; set; }
    }
}
