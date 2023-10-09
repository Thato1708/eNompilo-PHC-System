using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eNompilo.v3._0._1.Constants;
using Microsoft.AspNetCore.Identity;

namespace eNompilo.v3._0._1.Models.SystemUsers;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [Display(Name = "ID Number")]
    [StringLength(13, ErrorMessage = "The {0} must strictly be {1} characters long.", MinimumLength = 13)]
    public string IdNumber { get; set; }

    [Required]
    public Titles Titles { get; set; }

    [Required]
    [Display(Name = "First Name")]
    [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
    public string FirstName { get; set; }

    [Display(Name = "Middle Name")]
    [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
    public string? MiddleName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    [StringLength(120, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long.", MinimumLength = 2)]
    public string LastName { get; set; }

    [PersonalData]
    [Display(Name = "Email Address")]
    [EmailAddress]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter correct email format (username@domain.ext.cde)")]
    public override string? Email { get; set; }

    [Required]
    [PersonalData]
    [Display(Name = "Phone Number")]
    [StringLength(10, ErrorMessage = "Standard phone number can only be 10 digits long.", MinimumLength = 10)] //datatype must be number in view/html
    [RegularExpression(@"^((?:\+27|27)|0)(=|60|70|80|61|71|81|62|72|82|63|73|83|64|74|84|65|75|85|66|76|86|67|77|87|68|78|88|69|79|89)(\d{7})$", ErrorMessage = "Please enter a South African number.")]
    public override string PhoneNumber { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,}$", ErrorMessage = "Password must have at least:\n8 characters in length\n1 lowercase character\n1 uppercase letter\na numerical value\na special character")]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }

    [Display(Name = "Date Created On")]
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    [Display(Name = "User Role")]
    public UserRole UserRole { get; set; }

    public DateTime LastLogin { get; set; }

    public bool Archived { get; set; }
}

