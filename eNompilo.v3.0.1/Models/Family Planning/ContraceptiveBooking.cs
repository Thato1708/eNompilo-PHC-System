using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Family_Planning

{
    public class ContraceptiveBooking : Booking
    {
        [Required]
        [Display(Name = "Select Contraceptive")]
        public int SelectedContraceptive { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
