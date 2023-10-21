using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.GBV
{
    public class GbvRecommendations
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Practitioner")]
        [ForeignKey("Practitioner")]
        public int? PractitionerId { get; set; }

        [Required]
        [Display(Name = "Patient")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of the Recommendation")]
        public DateTime? Date { get; set; }


        [Required]
        [Display(Name = "Have you reffered the patient for further medical treatment ")]
        public bool Reffered { get; set; }

        [Required]
        [Display(Name = "Please enter your Recommendation here")]
        public string PractitionerRecommendation { get; set; }

        public virtual Patient? Patient { get; set; }
        public virtual Practitioner? Practitioner { get; set; }

        [Required]
        public bool Archived { get; set; }






    }
}
