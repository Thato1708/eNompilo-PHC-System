using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.Family_Planning;
using eNompilo.v3._0._1.Models.Vaccination;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.ViewModels
{
	[Keyless]
	public class AppointmentsViewModel
	{

		[ForeignKey("Patient")]
		public int? PatientId { get; set; }

		[ForeignKey("Practitioner")]
		public int? PractitionerId { get; set; }

		[Display(Name = "Confirm This Booking?")]
		public bool? SessionConfirmed { get; set; } = false;

		[ForeignKey("GeneralAppointment")]
		public int? GenAppointmentId { get; set; }

		[ForeignKey("CounsAppointment")]
		public int? CounsAppointmentId { get; set; }

		[ForeignKey("FPAppointment")]
		public int? FPAppointmentId { get; set; }

		[ForeignKey("VaxAppointment")]
		public int? VaxAppointmentId { get; set; }


        public List<GeneralAppointment>? GenAppointment { get; set; }

        public List<CounsellingAppointment>? CounsAppointment { get; set; }

        public List<FamilyPlanningAppointment>? FPAppointment { get; set; }

        public List<VaccinationAppointment>? VaxAppointment { get; set; }
    }
}