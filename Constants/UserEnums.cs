using System.ComponentModel.DataAnnotations;

namespace eNompilo.v3._0._1.Constants
{
	public enum Gender
	{
		[Display(Name = "Female")]
		Female,
		[Display(Name = "Male")]
		Male,
		[Display(Name = "Other")]
		Other
	}
	public enum Race
	{
		[Display(Name = "African")]
		African,
		[Display(Name = "Colored")]
		Colored,
		[Display(Name = "Indian")]
		Indian,
		[Display(Name = "White")]
		White,
		[Display(Name = "Other")]
		Other
	}
	public enum UserRole
	{
		[Display(Name = "Admin")]
		Admin,
		[Display(Name = "Patient")]
		Patient,
		[Display(Name = "Practitioner")]
		Practitioner,
		[Display(Name = "Receptionist")]
		Receptionist
	}
	public enum Citizenship
	{
		[Display(Name ="Citizenship by Birth")]
		Birth,
		[Display(Name = "Citizenship by Descent")]
		Descent,
		[Display(Name = "Citizenship by Naturalization")]
		Naturalization
	}
    public enum MaritalStatus
    {
		Married,
		Divorced,
		Partnership,
		Separated,
        Single,
		Widowed
    }
	public enum HearFromUs 
	{
		[Display(Name = "Social Media")]
		SocialMedia,
		Family,
		Friend,
		Doctor,
		Radio,
		Newspaper,
		School,
		[Display(Name = "Local Clinic")]
		LocalClinic,
		Other
	}
	public enum SessionPreference
	{
		Online,
		[Display(Name = "Face to Face/In-Person")]
		FaceToFace
	}
	public enum Provinces
	{
		[Display(Name = "Eastern Cape")]
		EasternCape,
		[Display(Name = "Free State")]
		FreeState,
		Gauteng,
		[Display(Name = "Kwa-Zulu Natal")]
		KwaZuluNatal,
		Limpopo,
		Mpumalanga,
		[Display(Name = "North West")]
		NorthWest,
		[Display(Name = "Northern Cape")]
		NorthernCape,
		[Display(Name = "Western Cape")]
		WesternCape

	}

    public enum Titles
    {
        Mx, Mr, Mrs, Miss, Ms, Dr, Prof, Rabbi, Rev
    }

	public enum PractitionerType
	{
		Counsellor, Nurse, Doctor
	}

	public enum CounsellorType
	{
		[Display(Name = "Marriage and family counsellor")]
		FamilyCounsellor,
        [Display(Name = "Mental health counsellor")]
        MentalHealthCounsellor,
        [Display(Name = "General counsellor")]
        GeneralCounsellor,
		[Display(Name = "Trauma counsellor")]
		TraumaCounsellor
	}

	public enum VaccinableDiseases
	{
		Chickenpox,
		Mumps,
		[Display(Name = "Hepatitis A")]
		HepatitisA,
		[Display(Name = "Hepatitis B")]
		HepatitisB,
		Measles,
		[Display(Name = "Human Papillomavirus (HPV)")]
		HPV,
		Smallpox,
		[Display(Name = "Tubercolosis (TB)")]
		TB,
		[Display(Name ="YellowFever")]
		YellowFever,
		Cholera,
		Rabies,
		[Display(Name = "Shingles (Herpes Zoster")]
		Herpes
	}

	public enum BookingReasons
	{
		Termination, [Display(Name = "Preventative Contraceptives")] PreventativeContraceptives, [Display(Name = "Emergency Contraceptives")] EmergencyContraceptives,
	}

	public enum EmotionalChallenges
	{
		issue1, issue2, issue3
	}
}
