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
    public override string? Email { get; set; }

    [Required]
    [PersonalData]
    [Display(Name = "Phone Number")]
    [StringLength(10, ErrorMessage = "Standard phone number can only be 10 digits long.", MinimumLength = 10)] //datatype must be number in view/html
    public override string PhoneNumber { get; set; }

    [Required]
    [DataType(DataType.Password)]
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

    public bool Archived { get; set; }
}

