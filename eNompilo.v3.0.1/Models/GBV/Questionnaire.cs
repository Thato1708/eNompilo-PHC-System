using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using System.Security.Policy;

namespace eNompilo.v3._0._1.Models.GBV
{
	public class Questionnaire
	{
		[Key]
		public int Id { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = "Do you stay with your immediate family members: ")]
		public bool familyOption { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = "Have you ever been exposed to violence where you stay: ")]
		public bool Violence { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = " Do you depend on someone financially: ")]
		public bool dependency {get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = "Are there any people you extremely fear: ")]
		public bool Fear { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = "Have you ever been physically abused: ")]
		public bool PhysAbuse { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = "Have you ever been sexually abused: ")]
		public bool Abuse { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = "Is there a person in which you confide in: ")]
		public bool Confide { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = "If you have ever experienced physical abuse, do you have any physical evidence: ")]
		public bool EvidenceType { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = "Are you comfortable in taking a lie detector test: ")]
		public bool DetectorTest { get; set; }

		[System.ComponentModel.DataAnnotations.Required]
		[Display(Name = "Have you ever contacted law enforcement regarding GBV: ")]
		public bool ContactLawEnforcement { get;set; }

        [System.ComponentModel.DataAnnotations.Required]
        public bool Archived { get; set; }

    }
}
