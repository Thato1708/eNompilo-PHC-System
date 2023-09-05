using System.ComponentModel.DataAnnotations;

namespace eNompilo.v3._0._1.Models
{
    public class PrescriptionMeds
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Medication Prescribed")]
        public string MedsPrescription { get; set; }

        [Required]
        [Display(Name = "Prescribed medication Description")]
        public string MedsDescription { get; set; }

        [Required]
        public bool Archived { get; set; }

    }
}
