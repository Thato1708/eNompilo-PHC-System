using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Family_Planning
{
    public class Booking
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public string Reason { get; set; }
        
    }
}
