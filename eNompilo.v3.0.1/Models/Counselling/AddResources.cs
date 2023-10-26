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

		[Required]
		[PersonalData]
		[Display(Name = "Image Name")]
		public string ImageName { get; set; }

		[NotMapped]
		[Display(Name = "Upload Image")]
		public IFormFile ImageFile { get; set; }

		[Required]
        public string Title { get; set; }

		[Required]
        public string Description { get; set; }

		[Required]
        public string YoutubeLink { get; set; }

		public bool Archived { get; set; } = false;


    }
}
