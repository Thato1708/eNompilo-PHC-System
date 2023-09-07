using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.GBV
{
    public class ReportGBV
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Required]
        public int PatientFileId { get; set; }
        [ForeignKey("PatientFileId")]
        public PatientFile PatientFile { get; set; }



        [Required]
        public bool Archived { get; set; }



    }
}
