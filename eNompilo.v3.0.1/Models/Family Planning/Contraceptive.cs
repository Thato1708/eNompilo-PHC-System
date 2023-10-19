using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Family_Planning

{
    public class Contraceptive
    {
        [Key]
        public int ContraceptiveId { get; set; }
        [Required]
        [Display(Name = "Contraceptive Name")]
        public string ContraceptiveName { get; set; }
        [Required]
        [Display(Name = "Contraceptive Description")]
        public string ContraceptiveDescription { get;set; }
        [Required]
        [Display(Name ="Contraceptive Duration in days")]
        public int ContraceptiveDuration { get; set; }
        [Required]
        public int IsActive { get; set; }
    }
}
