using System.ComponentModel.DataAnnotations;

using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Family_Planning

{
    public class Condition
    {
        [Key]
        public int ConditionId { get; set; }
        [Required]
        [Display(Name = "Select Condition")]
        public string ConditionDescription { get; set; }
    }
}

