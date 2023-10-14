using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Vaccination
{
    public class Certification
    {
        [Key]
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CertificateNo { get; set; }

        public DateTime IssuedDate { get; set; }


        [Required]
        [DisplayName("Patients")]
        public string PatientId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser Users { get; set; }



        [DisplayName("Vaccination Info")]
        public string DosesId { get; set; }
        [ForeignKey("DoseTrackingId")]
        public DoseTracking DoseTrackings { get; set; }




    }
}
