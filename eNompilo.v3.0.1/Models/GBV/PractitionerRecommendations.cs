using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.GBV
{
    public class PractitionerRecommendations
    {
        [Key]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name ="Name of Practitioner")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name ="Surname of the Practitioner")]
        public string Surname { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name ="Practitioner's Email Address ")]
        public String Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name ="Practitioner's Cell Number")]
        public String Cell { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [ForeignKey("Practitioner")]
        public int? PractitionerId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name ="Please enter your Recommendations here")]
        public string PractitionerRecommendation { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public bool Archived { get; set; }


    }
}
