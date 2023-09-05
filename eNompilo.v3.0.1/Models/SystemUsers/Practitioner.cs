using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eNompilo.v3._0._1.Models.SystemUsers
{
    public class Practitioner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser Users { get; set; }

        [Required]
        [Display(Name = "Practitioner Type")]
        public PractitionerType PractitionerType { get; set; }

        [Display(Name = "Counsellor Type")]
        public CounsellorType? CounsellorType { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public bool Archived { get; set; }
    }
}
