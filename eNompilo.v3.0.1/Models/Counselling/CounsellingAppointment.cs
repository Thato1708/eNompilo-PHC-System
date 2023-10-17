using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Counselling
{
    public class CounsellingAppointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Please select how would you like to conduct the upcoming session.")]
        public SessionPreference SessionPreference { get; set; }

        [Required]
        [Display(Name = "Please choose what challenges have you been facing lately.")]
        public EmotionalChallenges BookingReasons { get; set; }

        [Required]
        [Display(Name = "Can you please provide specific details on these challenges? This will help determine how best we can help you.")]
        public string ChallengesSpecific { get; set; }

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
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("Practitioner")]
        public int? PractitionerId { get; set; }

        [Required]
        public bool SessionConfirmed { get; set; } = false;

        [Required]
        public bool Archived { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual Practitioner? Practitioner { get; set; }
    }
}
