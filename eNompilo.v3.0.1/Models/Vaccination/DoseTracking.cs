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
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        

        [Required][DisplayName("Recieved vaccine")]
        [ForeignKey("VaccinationInventory")]
        public int VaccineInventoryId { get; set; }

        [Required]
        [DisplayName("Date Administered")]
        public DateTime DateAdministered { get; set; }

        [DisplayName("Second Dose Date")]
        public DateTime? SecondDose { get; set; }


        [Required]
        [DisplayName("Site Address")]
        public string SiteAddress { get; set; }

        [Required]
        public bool Archived { get; set; }

        [Required]
        public string CertificateNo { get; set; }

        public DateTime IssuedDate { get; set; } = DateTime.Now;

        public virtual Patient? Patient { get; set; }
        public virtual VaccinationInventory? VaccinationInventory { get; set; }
    }
}
