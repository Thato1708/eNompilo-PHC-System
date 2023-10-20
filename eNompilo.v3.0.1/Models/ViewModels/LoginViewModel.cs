using eNompilo.v3._0._1.Models.SystemUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.ViewModels
{
    public class LoginViewModel
    {
        [ForeignKey("Users")]
        public string? UsersId { get; set; }

        [Display(Name = "User Name")]
        public string? IdNumber { get; set; }

        [Display(Name = "Password")]
		[DataType(DataType.Password)]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,}$", ErrorMessage = "Password must have at least:\n8 characters in length\n1 lowercase character\n1 uppercase letter\na numerical value\na special character")]
		public string? Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public virtual ApplicationUser? Users { get; set; }
    }
}
