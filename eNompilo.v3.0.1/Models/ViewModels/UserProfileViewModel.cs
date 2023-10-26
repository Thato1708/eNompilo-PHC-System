using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.Family_Planning;
using eNompilo.v3._0._1.Models.SMP;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Models.Vaccination;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.ViewModels
{
    public class UserProfileViewModel
    {
        [ForeignKey("ApplicationUser")]
        public string AppUserId { get; set; }

        [ForeignKey("Admin")]
        public int? AdminId { get; set; }

        [ForeignKey("PatientFile")]
        public int? PatientId { get; set; }

        [ForeignKey("Practitioner")]
        public int? PractitionerId { get; set; }

        [ForeignKey("Receptionist")]
        public int? ReceptionistId { get; set; }

        [ForeignKey("PersonalDetails")]
        public int? PersonalDetailsId { get; set; }

        [ForeignKey("CounsellingAppointment")]
        public int? CounsellingAppointmentId { get; set; }

        [ForeignKey("GeneralAppointment")]
        public int? GeneralAppointmentId { get; set; }

        [ForeignKey("FPAppointment")]
        public int? FPAppointmentId { get; set; }

        [ForeignKey("VaccinationAppointment")]
        public int? VaccinationAppointmentId { get; set; }

        [ForeignKey("SMPAppointment")]
        public int? SMPAppoinmentId { get; set; }

        public DateTime LastLogin { get; set; }

        public virtual ApplicationUser ApplicationUsers { get; set; }
        public virtual Admin Admins { get; set; }
        public virtual PatientFile PatientFiles { get; set; }
        public virtual PersonalDetails PersonalDetails { get; set; }
        public virtual Practitioner Practitioners { get; set; }
        public virtual Receptionist Receptionists { get; set; }


        public List<GeneralAppointment>? GeneralAppointment { get; set; }

        public List<CounsellingAppointment>? CounsellingAppointment { get; set; }

        public List<FamilyPlanningAppointment>? FPAppointment { get; set; }

        public List<VaccinationAppointment>? VaccinationAppointment { get; set; }
        public List<SMPAppointment>? SMPAppointment { get; set; }


    }
}
