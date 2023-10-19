using eNompilo.v3._0._1.Models.Vaccination;
using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.Family_Planning;
using System.ComponentModel.DataAnnotations.Schema;
using eNompilo.v3._0._1.Migrations;

namespace eNompilo.v3._0._1.Models.ViewModels
{
    public class ArchiveItemViewModel
    {
        public int Id { get; set; }
        public bool Archived { get; set; }

        [ForeignKey("GeneralAppointment")]
        public int? GenAppointmentId { get; set; }
        public virtual GeneralAppointment? GenAppointment { get; set; }

        [ForeignKey("CounsAppointment")]
        public int? CounsAppointmentId { get; set; }
        public virtual CounsellingAppointment? CounsAppointment { get; set; }

        [ForeignKey("FPAppointment")]
        public int? FPAppointmentId { get; set; }
        public virtual FamilyPlanningAppointment? FPAppointment { get; set; }

        [ForeignKey("VaxAppointment")]
        public int? VaxAppointmentId { get; set; }
        public virtual VaccinationAppointment? VaxAppointment { get; set; }

        [ForeignKey("DoseTracking")]
        public int? DoseTrackingID { get; set; }
        public virtual DoseTracking? DoseTracking { get; set; }

        [ForeignKey("VaccinationInventory")]
        public int? VaxInventoryID { get; set; }
        public virtual VaccinationInventory? VaccinationInventory { get; set; }

        [ForeignKey("ProcedureAppointment")]
        public int? ProcedureAppointmentId { get; set; }
        public virtual MedicalProceduresAppointment? ProceduresAppointment { get; set; }
    }
}
