using System.ComponentModel.DataAnnotations;

namespace eNompilo.v3._0._1.Data
{
    public class AppointmentViewModel
    {
        [Display(Name = "Reason")]
        public string Reason { get; set; }
        public string Contraceptive { get; set; }
        public DateTime Date { get; set;}
        public int Id { get; set;}
    }
}
