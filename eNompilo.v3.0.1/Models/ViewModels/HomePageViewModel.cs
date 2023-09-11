using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.Family_Planning;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Models.Vaccination;

namespace eNompilo.v3._0._1.Models.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<GeneralAppointment> GeneralAppointments { get; set; }
        public IEnumerable<CounsellingAppointment> CounsellingAppointments { get; set; }
        public IEnumerable<FamilyPlanningAppointment> FamilyPlanningAppointments { get; set; }
        public IEnumerable<VaccinationAppointment> VaccinationAppointments { get; set; }



        //Added for loginPartial, otherwise ignore
        public ApplicationUser AppUser { get; set; }
        public Patient Patient { get; set; }
        public Practitioner Practitioner { get; set; }
        public Admin Admin { get; set; }
        public Receptionist Receptionist { get; set; }
        public PersonalDetails PersonalDetails { get; set; }
    }
}
