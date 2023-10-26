using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace eNompilo.v3._0._1.Models.Counselling
{
	public class AddResources
	{
		[Key]
		public int Id { get; set; }

		[PersonalData]
		[Display(Name = "Profile Picture")]
		public string? ProfilePicture { get; set; }

		[NotMapped]
		[Display(Name = "Upload Profile Image")]
		public IFormFile? ProfilePictureImageFile { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
		[Required]

        public string YoutubeLink { get; set; }
    }
}
