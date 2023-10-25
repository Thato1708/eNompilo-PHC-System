using eNompilo.v3._0._1.Models.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "Patient")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Practitioner")]
        [ForeignKey("Practitioner")]
        public int PractitionerId { get; set; }

        [Required]
        public bool Archived { get; set; }

        public virtual Patient? Patient { get; set; }
        public virtual Practitioner? Practitioner { get; set; }

    }
}
