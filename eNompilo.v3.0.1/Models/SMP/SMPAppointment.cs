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
		[Display(Name ="Anaesthesia reaction")]
		public bool AnaesthesiaReaction { get; set; }

		[Display(Name ="Nature of reaction")]
		public string? NatureOfReaction { get; set; }

		[Required]
		[Display(Name ="BreathingtubeSurgery")]
		public bool BreathingtubeSurgery { get; set; }

		[Required]
		[Display(Name ="Movement")]
		public bool Movement { get; set; }

		[Required]
		[Display(Name ="HeartAttack")]
		public bool HeartAttack { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
		[DataType(DataType.Date)]
		[Display(Name ="HeartAttack Date")]
		public DateTime? HeartAttackDate { get; set; }

		[Required]
		[Display(Name ="Diabetes")]
		public bool DiabetesQuestion { get; set; }

		[Required]
		[Display(Name ="Insulin")]
		public bool InsulinQuestion { get; set; }

		[Required]
		public bool Archived { get; set; }

		[Required]
		public int PatientId { get; set; }
		[ForeignKey("PatientId")]
		public Patient Patient { get; set; }

		[Required]
		public int PatientFileId { get; set; }
		[ForeignKey("PatientFileId")]
		public PatientFile PatientFile { get; set; }
	}
}
