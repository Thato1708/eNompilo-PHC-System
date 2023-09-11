using eNompilo.v3._0._1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Linq;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Constants;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Models.ViewModels;

namespace eNompilo.v3._0._1.Controllers
{
	public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;


        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor contextAccessor)
		{
			_logger = logger;
			_userManager = userManager;	
			_context = context;
			_signInManager = signInManager;
			_contextAccessor = contextAccessor;
		}

		

		public IActionResult Index()
		{
			if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Patient))
			{
				var userId = _userManager.GetUserId(User);
				var patient = _context.tblPatient.SingleOrDefault(c => c.UserId == userId);
				var patientId = patient.Id;
				HttpContext.Session.SetInt32("PatientId", patientId);

                var patientFile = _context.tblPatientFile.SingleOrDefault(c => c.PatientId == patientId);
                var patientFileId = patientFile.Id;
                HttpContext.Session.SetInt32("PatientFileId", patientFileId);

				ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;

				//var generalAppointment = _context.tblGeneralAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
				//var counsellingAppointment = _context.tblCounsellingAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
				//var fpAppointment = _context.tblFamilyPlanningAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
				//var vaccinationAppointment = _context.tblVaccinationAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
				var personalDetails = _context.tblPersonalDetails.Where(p => p.PatientId == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    //GeneralAppointments = generalAppointment,
                    //CounsellingAppointments = counsellingAppointment,
                    //FamilyPlanningAppointments = fpAppointment,
                    //VaccinationAppointments = vaccinationAppointment,
					PersonalDetails = personalDetails
                };

                return View(viewModel);
            }
			else if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Admin))
			{
				var userId = _userManager.GetUserId(User);
				var patient = _context.tblAdmin.SingleOrDefault(c => c.UserId == userId);
				var patientId = patient.Id;
				HttpContext.Session.SetInt32("AdminId", patientId);
            }
			else if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Practitioner))
			{
				var userId = _userManager.GetUserId(User);
				var patient = _context.tblPractitioner.SingleOrDefault(c => c.UserId == userId);
				var patientId = patient.Id;
				HttpContext.Session.SetInt32("PractitionerId", patientId);
            }
			else if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Receptionist))
			{
				var userId = _userManager.GetUserId(User);
				var patient = _context.tblReceptionist.SingleOrDefault(c => c.UserId == userId);
				var patientId = patient.Id;
				HttpContext.Session.SetInt32("ReceptionistId", patientId);
            }

			return View();
		}

		public IActionResult SelfHelp()
		{
			return View();
		}

		public IActionResult EmergencyLine()
		{
            if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Patient))
            {
                var userId = _userManager.GetUserId(User);
                var patient = _context.tblPatient.SingleOrDefault(c => c.UserId == userId);
                var patientId = patient.Id;
                HttpContext.Session.SetInt32("PatientId", patientId);

                var patientFile = _context.tblPatientFile.SingleOrDefault(c => c.PatientId == patientId);
                var patientFileId = patientFile.Id;
                HttpContext.Session.SetInt32("PatientFileId", patientFileId);

                ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;

                //var generalAppointment = _context.tblGeneralAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var counsellingAppointment = _context.tblCounsellingAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var fpAppointment = _context.tblFamilyPlanningAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var vaccinationAppointment = _context.tblVaccinationAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                var personalDetails = _context.tblPersonalDetails.Where(p => p.PatientId == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    //GeneralAppointments = generalAppointment,
                    //CounsellingAppointments = counsellingAppointment,
                    //FamilyPlanningAppointments = fpAppointment,
                    //VaccinationAppointments = vaccinationAppointment,
                    PersonalDetails = personalDetails
                };

                return View(viewModel);
            }
            return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult EmptyPage()
		{
            if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Patient))
            {
                var userId = _userManager.GetUserId(User);
                var patient = _context.tblPatient.SingleOrDefault(c => c.UserId == userId);
                var patientId = patient.Id;
                HttpContext.Session.SetInt32("PatientId", patientId);

                var patientFile = _context.tblPatientFile.SingleOrDefault(c => c.PatientId == patientId);
                var patientFileId = patientFile.Id;
                HttpContext.Session.SetInt32("PatientFileId", patientFileId);

                ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;

                //var generalAppointment = _context.tblGeneralAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var counsellingAppointment = _context.tblCounsellingAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var fpAppointment = _context.tblFamilyPlanningAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var vaccinationAppointment = _context.tblVaccinationAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                var personalDetails = _context.tblPersonalDetails.Where(p => p.PatientId == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    //GeneralAppointments = generalAppointment,
                    //CounsellingAppointments = counsellingAppointment,
                    //FamilyPlanningAppointments = fpAppointment,
                    //VaccinationAppointments = vaccinationAppointment,
                    PersonalDetails = personalDetails
                };

                return View(viewModel);
            }
            return View();
		}

        public IActionResult PageComingSoon()
		{
            if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Patient))
            {
                var userId = _userManager.GetUserId(User);
                var patient = _context.tblPatient.SingleOrDefault(c => c.UserId == userId);
                var patientId = patient.Id;
                HttpContext.Session.SetInt32("PatientId", patientId);

                var patientFile = _context.tblPatientFile.SingleOrDefault(c => c.PatientId == patientId);
                var patientFileId = patientFile.Id;
                HttpContext.Session.SetInt32("PatientFileId", patientFileId);

                ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;

                //var generalAppointment = _context.tblGeneralAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var counsellingAppointment = _context.tblCounsellingAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var fpAppointment = _context.tblFamilyPlanningAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var vaccinationAppointment = _context.tblVaccinationAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                var personalDetails = _context.tblPersonalDetails.Where(p => p.PatientId == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    //GeneralAppointments = generalAppointment,
                    //CounsellingAppointments = counsellingAppointment,
                    //FamilyPlanningAppointments = fpAppointment,
                    //VaccinationAppointments = vaccinationAppointment,
                    PersonalDetails = personalDetails
                };

                return View(viewModel);
            }
            return View();
		}

		public IActionResult OurServices()
		{
            if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Patient))
            {
                var userId = _userManager.GetUserId(User);
                var patient = _context.tblPatient.SingleOrDefault(c => c.UserId == userId);
                var patientId = patient.Id;
                HttpContext.Session.SetInt32("PatientId", patientId);

                var patientFile = _context.tblPatientFile.SingleOrDefault(c => c.PatientId == patientId);
                var patientFileId = patientFile.Id;
                HttpContext.Session.SetInt32("PatientFileId", patientFileId);

                ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;

                //var generalAppointment = _context.tblGeneralAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var counsellingAppointment = _context.tblCounsellingAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var fpAppointment = _context.tblFamilyPlanningAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var vaccinationAppointment = _context.tblVaccinationAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                var personalDetails = _context.tblPersonalDetails.Where(p => p.PatientId == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    //GeneralAppointments = generalAppointment,
                    //CounsellingAppointments = counsellingAppointment,
                    //FamilyPlanningAppointments = fpAppointment,
                    //VaccinationAppointments = vaccinationAppointment,
                    PersonalDetails = personalDetails
                };

                return View(viewModel);
            }
            return View();
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		//Temporary For receptionist
		
		public IActionResult ReceptionistDashboard()
		{
			return View();
		}

		//Temporary PractitionerDash

		public IActionResult PractitionerDashboard()
		{
			return View();
		}
		//temorary AdminDash
		public IActionResult AdminDashboard()
		{
			return View();
		}
		public IActionResult EmergencyHotlines()
		{
            if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Patient))
            {
                var userId = _userManager.GetUserId(User);
                var patient = _context.tblPatient.SingleOrDefault(c => c.UserId == userId);
                var patientId = patient.Id;
                HttpContext.Session.SetInt32("PatientId", patientId);

                var patientFile = _context.tblPatientFile.SingleOrDefault(c => c.PatientId == patientId);
                var patientFileId = patientFile.Id;
                HttpContext.Session.SetInt32("PatientFileId", patientFileId);

                ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;

                //var generalAppointment = _context.tblGeneralAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var counsellingAppointment = _context.tblCounsellingAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var fpAppointment = _context.tblFamilyPlanningAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var vaccinationAppointment = _context.tblVaccinationAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                var personalDetails = _context.tblPersonalDetails.Where(p => p.PatientId == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    //GeneralAppointments = generalAppointment,
                    //CounsellingAppointments = counsellingAppointment,
                    //FamilyPlanningAppointments = fpAppointment,
                    //VaccinationAppointments = vaccinationAppointment,
                    PersonalDetails = personalDetails
                };

                return View(viewModel);
            }
            return View();
		}
		public IActionResult SpecialisedMedicalProcedures()
		{
            if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Patient))
            {
                var userId = _userManager.GetUserId(User);
                var patient = _context.tblPatient.SingleOrDefault(c => c.UserId == userId);
                var patientId = patient.Id;
                HttpContext.Session.SetInt32("PatientId", patientId);

                var patientFile = _context.tblPatientFile.SingleOrDefault(c => c.PatientId == patientId);
                var patientFileId = patientFile.Id;
                HttpContext.Session.SetInt32("PatientFileId", patientFileId);

                ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;

                //var generalAppointment = _context.tblGeneralAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var counsellingAppointment = _context.tblCounsellingAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var fpAppointment = _context.tblFamilyPlanningAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                //var vaccinationAppointment = _context.tblVaccinationAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
                var personalDetails = _context.tblPersonalDetails.Where(p => p.PatientId == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    //GeneralAppointments = generalAppointment,
                    //CounsellingAppointments = counsellingAppointment,
                    //FamilyPlanningAppointments = fpAppointment,
                    //VaccinationAppointments = vaccinationAppointment,
                    PersonalDetails = personalDetails
                };

                return View(viewModel);
            }
            return View();
		}

		public IActionResult SplashScreen()
		{
			return View();
		}
		
		public IActionResult Vaccination()
		{
			return View();
		}
	}
}