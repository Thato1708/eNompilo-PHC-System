using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.Vaccination;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.SystemUsers
{
    public class PatientFile
    {
        [Key]
        public int Id { get; set; }

        [PersonalData]
        [ForeignKey("Patient")]
        public int? PatientId { get; set; }

        [PersonalData]
        [ForeignKey("PersonalDetails")]
        public int? PersonalDetailsId { get; set; }

        [PersonalData]
        [ForeignKey("MedicalHistory")]
        public int? MedicalHistoryId { get; set; }

        [PersonalData]
        public int? VaccinationAppointmentId { get; set; }
        [ForeignKey("VaccinationAppointmentId")]
        List<VaccinationAppointment>? VaccinationAppointments { get; set; }
        [PersonalData]
        public int? CounsellorAppointmentId { get; set; }
        [ForeignKey("CounsellorAppointmentId")]
        List<CounsellingAppointment>? CounsellingAppointments { get; set; }
        [PersonalData]
        public int? GeneralAppointmentId { get; set; }
        [ForeignKey("GeneralAppointmentId")]
        List<GeneralAppointment>? GeneralAppointments { get; set; }

        [PersonalData]
        public int? SessionsId { get; set; }
        [ForeignKey("SessionsId")]
        List<Session>? Sessions { get; set; }

        [Required]
        public bool Archived { get; set; } = false;

        public Patient Patient { get; set; } //Can it be created when a patient is created?
        public PersonalDetails PersonalDetails { get; set; } 
        public MedicalHistory MedicalHistory { get; set; }
    }
}
