using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.Family_Planning;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Models.Vaccination;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.ViewModels
{
	public class AppointmentsViewModel
	{
        public int Id { get; set; }

        [ForeignKey("Patient")]
		public int PatientId { get; set; }

		[ForeignKey("Practitioner")]
		public int? PractitionerId { get; set; }

		[Display(Name = "Confirm This Booking?")]
		public bool SessionConfirmed { get; set; }

		[ForeignKey("GeneralAppointment")]
		public int? GenAppointmentId { get; set; }

		[ForeignKey("CounsAppointment")]
		public int? CounsAppointmentId { get; set; }

		[ForeignKey("FPAppointment")]
		public int? FPAppointmentId { get; set; }

		[ForeignKey("VaxAppointment")]
		public int? VaxAppointmentId { get; set; }


		public virtual Patient? Patient { get; set; }
		public virtual Practitioner? Practitioner { get; set; }
        public virtual GeneralAppointment? GenAppointment { get; set; }

        public virtual CounsellingAppointment? CounsAppointment { get; set; }

        public virtual FamilyPlanningAppointment? FPAppointment { get; set; }

        public virtual VaccinationAppointment? VaxAppointment { get; set; }


        public List<GeneralAppointment>? GenAppointmentList { get; set; }

        public List<CounsellingAppointment>? CounsAppointmentList { get; set; }

        public List<FamilyPlanningAppointment>? FPAppointmentList { get; set; }

        public List<VaccinationAppointment>? VaxAppointmentList { get; set; }
    }
}