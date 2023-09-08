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
        [Display(Name = "I am the: ")]
        public Role Role { get; set; }

        [Required]
        [Display(Name ="Would like to stay anonymous: ")]
        public IdentityType IdentityType { get; set; }

        [Required]
        [Display(Name = "Incident Type: ")]
        public IncidentType IncidentType { get; set; }

        [Required]
        [Display(Name = "What is your preferred method of communication: ")]
        public CommunicationType CommunicationType { get; set; }

        [Required]
        [Display(Name = "Would you like to be booked for counselling: ")]
        public CounsellingBooking CounsellingBooking { get; set; }

        [Required]
        public bool Archived { get; set; }
    }
}
