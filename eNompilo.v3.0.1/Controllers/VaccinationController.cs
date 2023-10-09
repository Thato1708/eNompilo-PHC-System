﻿using eNompilo.v3._0._1.Models;
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
using eNompilo.v3._0._1.Models.Vaccination;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eNompilo.v3._0._1.Controllers
{
    public class VaccinationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VaccinationController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;


        public VaccinationController(ILogger<VaccinationController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(RoleConstants.Practitioner))
            {
                IEnumerable<VaccinationInventory> objList = _context.tblVaccinationInventory;
                return View(objList);
            }
            return View();
        }

        public IActionResult DoseTracking()
        {
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DoseTracking(DoseTracking model)
        {
            DoseTracking doseTracking = new DoseTracking 
            {
                PatientId = model.PatientId,
                VaccineAdministered = model.VaccineAdministered,
                DateAdministered = model.DateAdministered,
                SecondDose = model.SecondDose,
                SiteAddress = model.SiteAddress,
            };

            //if (ModelState.IsValid)
            //{
                _context.tblDoseTracking.Add(doseTracking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View();
        }

        public IActionResult VaccinationInventory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VaccinationInventory(VaccinationInventory model)
        {
            if (ModelState.IsValid)
            {
                _context.tblVaccinationInventory.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult PrivacyandSecurity()
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

                var admin = _context.tblAdmin.Where(p => p.Id == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    Admin = admin
                };

                return View(viewModel);
            }
            else if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Practitioner))
            {
                var userId = _userManager.GetUserId(User);
                var patient = _context.tblPractitioner.SingleOrDefault(c => c.UserId == userId);
                var patientId = patient.Id;
                HttpContext.Session.SetInt32("PractitionerId", patientId);

                var practitioner = _context.tblPractitioner.Where(p => p.Id == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    Practitioner = practitioner
                };

                return View(viewModel);
            }
            else if (_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Receptionist))
            {
                var userId = _userManager.GetUserId(User);
                var patient = _context.tblReceptionist.SingleOrDefault(c => c.UserId == userId);
                var patientId = patient.Id;
                HttpContext.Session.SetInt32("ReceptionistId", patientId);

                var receptionist = _context.tblReceptionist.Where(p => p.Id == patientId).FirstOrDefault();

                HomePageViewModel viewModel = new HomePageViewModel()
                {
                    Receptionist = receptionist
                };

                return View(viewModel);
            }
            return View();
        }
    }
}
