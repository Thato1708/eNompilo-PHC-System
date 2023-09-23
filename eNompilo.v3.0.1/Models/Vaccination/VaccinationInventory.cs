using System.ComponentModel.DataAnnotations;
using eNompilo.v3._0._1.Constants;

namespace eNompilo.v3._0._1.Models.Vaccination
{
    public class VaccinationInventory
    {
        [Key]
        public int ID { get; set; }

        public VaccinableDiseases Vaccine { get; set; }
        public int Quantity { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
