using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Family_Planning

{
    public class SelectedCondition
    {
        [Key]
        public int SelectedConditionID { get; set; }
        //[Required]
        //public int ConditionID { get; set; }
        [Required]
        public string PatientID { get; set; }
        public string ConditionDescription { get; set; }

    }
}
