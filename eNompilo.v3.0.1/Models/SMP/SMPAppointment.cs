using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace eNompilo.v3._0._1.Models.SMP
{
	public class SMPAppointment
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Have you or a family member ever had a serious reaction to anesthesia (other than nausea and vomiting)?")]
		public bool AnaesthesiaReaction { get; set; }

		[Display(Name ="Nature of reaction")]
		public string? NatureOfReaction { get; set; }

		[Required]
		[Display(Name = "If you have had surgery, were you told that it was to put in a breathing tube?")]
		public bool BreathingtubeSurgery { get; set; }

		[Required]
		[Display(Name = "Do you have any difficulty opening your mouth or moving your head or neck?")]
		public bool Movement { get; set; }

		[Required]
		[Display(Name = "Have you ever had a heartattack or a myocardial infarction?")]
		public bool HeartAttack { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
		[DataType(DataType.Date)]
		[Display(Name ="Heart Attack Date")]
		public DateTime? HeartAttackDate { get; set; }

		[Required]
		[Display(Name = "Do you have diabetes or a problem with high blood sugars?")]
		public bool DiabetesQuestion { get; set; }

		[Required]
		[Display(Name = "If you have diabetes, are you taking insulin?")]
		public bool InsulinQuestion { get; set; }

		[Required]
		[ForeignKey("Patient")]
		public int PatientId { get; set; }

        public bool Archived { get; set; }
		public virtual Patient? Patient { get; set; }
    }
}
