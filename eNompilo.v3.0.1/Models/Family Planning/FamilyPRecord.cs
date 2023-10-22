using eNompilo.v3._0._1.Models.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Family_Planning
{
    public class FamilyPRecord
    {
        [Key]
        public int Id { get; set; }

       
        [Display(Name = "Doctor")]
        public string? DoctorId { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Date of Visit")]
        public DateTime? DateOfVisit { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Medical Notes")]
        public string? MedicalNotes { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }


        [Display(Name = "Is Discontinued")]
        public bool? IsDiscontinued { get; set; }

        [Display(Name = "Dosage Amount")]
        public string? DosageAmount { get; set; }

        [Display(Name = "Dosage Duration")]
        public string? DosageDuration { get; set; }

        public int FamilyPlanningAppointmentId { get; set; }
        [ForeignKey("FamilyPlanningAppointmentId")]
        public FamilyPlanningAppointment? FamilyPlanningAppointment { get; set; }

        [ForeignKey("DoctorId")]
        public ApplicationUser? Doctor { get; set; }
    }
}
