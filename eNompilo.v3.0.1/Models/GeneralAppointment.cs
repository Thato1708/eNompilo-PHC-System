using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.SystemUsers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eNompilo.v3._0._1.Models
{
    public class GeneralAppointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Please tell us in as much detail as you can about your issue.")]
        public string PatientIssues { get; set; }

        [NotMapped]
        public int PractitionerDiaryId { get; set; }
        [NotMapped]
        [ForeignKey("PractitionerDiaryId")]
        public PractitionerDiary PractitionerDiary { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Please choose an available date you'd prefer")]
        public DateTime? PreferredDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: HH:mm}")]
        [DataType(DataType.Time)]
        [Display(Name = "Please choose an available time you'd prefer")]
        public DateTime? PreferredTime { get; set; }

        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Required]
        public int PatientFileId { get; set; }
        [ForeignKey("PatientFileId")]
        public PatientFile PatientFile { get; set; }

        [Required]
        public bool SessionConfirmed { get; set; } = false;

        [Required]
        public bool Archived { get; set; }
    }
}
