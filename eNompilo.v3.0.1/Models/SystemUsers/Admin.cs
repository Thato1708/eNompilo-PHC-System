using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace eNompilo.v3._0._1.Models.SystemUsers
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [PersonalData]
        [Display(Name = "Profile Picture")]
        public string? ProfilePicture { get; set; }

        [NotMapped]
        [Display(Name = "Upload Profile Picture")]
        public IFormFile? ProfilePictureImageFile { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public bool Archived { get; set; }
        public ApplicationUser Users { get; set; }
    }
}