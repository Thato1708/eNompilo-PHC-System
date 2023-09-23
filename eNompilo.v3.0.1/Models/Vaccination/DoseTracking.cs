using System.ComponentModel.DataAnnotations;
using eNompilo.v3._0._1.Constants;

namespace eNompilo.v3._0._1.Models.Vaccination
{
    public class DoseTracking
    {
        [Key]
        public int ID { get; set; }
        public string VaccineAdministered { get; set; }
        public DateOnly DateAdministered { get; set; }
        public DateOnly? SecondDose { get; set; }
        public VaccinableDiseases Vaccine { get; set; }
        public string SiteAddress { get; set; }
    }
}
