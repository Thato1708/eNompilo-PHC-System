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
        [DisplayName("Patients")]
        public int? PatientId { get; set; }
        

        [Required][DisplayName("Recieved vaccine")]
        public int? VaccineInventoryId { get; set; }

        [Required]
        [DisplayName("Date Administered")]
        public DateTime DateAdministered { get; set; }

        [DisplayName("Second Dose Date")]
        public DateTime? SecondDose { get; set; }


        [Required]
        [DisplayName("Site Address")]
        public string SiteAddress { get; set; }

        public IEnumerable<Patient>? Patient { get; set; }
        public IEnumerable<VaccinationInventory>? VaccinationInventory { get; set; }
    }
}
