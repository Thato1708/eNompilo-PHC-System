using eNompilo.v3._0._1.Models.SystemUsers;

namespace eNompilo.v3._0._1.Models.ViewModels
{
	public class UserTypeViewModel
	{
		public ApplicationUser AppUser { get; set; }
		public Patient Patient { get; set; }
        public PersonalDetails PersonalDetails { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public Practitioner Practitioner { get; set; }
		public Admin Admin { get; set; }
		public Receptionist Receptionist { get; set; }
    }
}
