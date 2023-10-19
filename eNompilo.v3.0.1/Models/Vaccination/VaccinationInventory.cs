using eNompilo.v3._0._1.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eNompilo.v3._0._1.Models.Vaccination
{
    public class VaccinationInventory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Batch number")]
        public int BatchNo { get; set; }

        [Required]
        [DisplayName("Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [DisplayName("Vaccine for: ")]
        public VaccinableDiseases Diseases { get; set; }

        [DisplayName("Vaccine name")]
        public string VaccineName { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Expiration Date")]
        public DateTime ExpirationDate { get; set; }

    }
}
