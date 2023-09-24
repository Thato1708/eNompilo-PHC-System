using eNompilo.v3._0._1.Models.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.ViewModels
{
    public class UserProfileViewModel
    {
        [ForeignKey("ApplicationUser")]
        public string AppUserId { get; set; }

        [ForeignKey("Admin")]
        public int? AdminId { get; set; }

        [ForeignKey("PatientFile")]
        public int? PatientId { get; set; }

        [ForeignKey("Practitioner")]
        public int? PractitionerId { get; set; }

        [ForeignKey("Receptionist")]
        public int? ReceptionistId { get; set; }

        [ForeignKey("PersonalDetails")]
        public int? PersonalDetailsId { get; set; }

        public DateTime LastLogin { get; set; }

        public virtual ApplicationUser ApplicationUsers { get; set; }
        public virtual Admin Admins { get; set; }
        public virtual PatientFile PatientFiles { get; set; }
        public virtual PersonalDetails PersonalDetails { get; set; }
        public virtual Practitioner Practitioners { get; set; }
        public virtual Receptionist Receptionists { get; set; }

    }
}
