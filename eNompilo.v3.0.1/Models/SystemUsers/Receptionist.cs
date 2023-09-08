﻿using eNompilo.v3._0._1.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace eNompilo.v3._0._1.Models.SystemUsers
{
    public class Receptionist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser Users { get; set; }

		//[PersonalData]
		//[Display(Name = "Profile Picture")]
		//public string? ProfilePicture { get; set; }

		//[NotMapped]
		//[Display(Name = "Upload Profile Picture")]
		//public IFormFile? ProfilePictureImageFile { get; set; }

		[Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public bool Archived { get; set; }
    }
}