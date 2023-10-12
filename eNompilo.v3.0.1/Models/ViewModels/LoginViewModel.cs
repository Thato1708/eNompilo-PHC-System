using eNompilo.v3._0._1.Models.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.ViewModels
{
    public class LoginViewModel
    {
        [ForeignKey("Users")]
        public string? UsersId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string IdNumber { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public virtual ApplicationUser? Users { get; set; }
    }
}
