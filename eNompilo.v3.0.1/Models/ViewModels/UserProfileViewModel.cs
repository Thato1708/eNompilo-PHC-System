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

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual PatientFile PatientFile { get; set; }
        public virtual Practitioner Practitioner { get; set; }
        public virtual Receptionist Receptionist { get; set; }

    }
}
