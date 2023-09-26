using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;

namespace eNompilo.v3._0._1.Models.Vaccination
{
    public class DoseTracking
    {
        [Key]
        public int ID { get; set; }

        [PersonalData]
        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        

        [Required]
        public string VaccineAdministered { get; set; }

        [Required]
        public DateTime DateAdministered { get; set; }
        public DateTime? SecondDose { get; set; }

        [Required]
        [DisplayName("Recieved vaccine")]
        public VaccinableDiseases Vaccine { get; set; }

        [Required]
        public string SiteAddress { get; set; }

        public Patient Patient { get; set; }
    }
}
