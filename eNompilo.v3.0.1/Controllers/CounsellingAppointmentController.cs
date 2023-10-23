using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Models.ViewModels;

namespace eNompiloCounselling.Controllers
{
    [Authorize]
    public class CounsellingAppointmentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CounsellingAppointmentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
			{
				ViewBag.CASuccessMessage = TempData["CASuccessMessage"] as string;
				ViewBag.CAUpdateSuccessMessage = TempData["CAUpdateSuccessMessage"] as string;
				if (User.IsInRole(RoleConstants.Patient) || User.IsInRole(RoleConstants.Receptionist))
                {
                    IEnumerable<CounsellingAppointment> objList = dbContext.tblCounsellingAppointment.Where(va => va.Archived == false).Include(pr => pr.Practitioner).ThenInclude(u => u.Users).Include(p => p.Patient).ThenInclude(u => u.Users).ToList();
                    return View(objList);
                }
                else if (User.IsInRole(RoleConstants.Admin))
                {
                    IEnumerable<CounsellingAppointment> objList = dbContext.tblCounsellingAppointment.Include(pr => pr.Practitioner).ThenInclude(u => u.Users).Include(p => p.Patient).ThenInclude(u => u.Users);
                    return View(objList);
                }
                else if (User.IsInRole(RoleConstants.Practitioner))
                {
                    IEnumerable<CounsellingAppointment> objList = dbContext.tblCounsellingAppointment.Where(va => va.Archived == false).Include(pr => pr.Practitioner).ThenInclude(u => u.Users).Include(p => p.Patient).ThenInclude(u => u.Users).ToList();
                    return View(objList);
                }
            }
      
            return NotFound();
        }
    

        public IActionResult Book()
        {
            var bookedAppointments = dbContext.tblCounsellingAppointment
                .Select(a => new { a.PractitionerId, a.PreferredDate, a.PreferredTime })
                .ToList();

            ViewBag.BookedAppointments = bookedAppointments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(CounsellingAppointment model)
        {
            if(model.BookingReasons != null && model.ChallengesSpecific != null && model.SessionPreference != null && model.PreferredDate != null && model.PreferredTime != null && model.PatientId != null)
			{
				CounsellingAppointment ca = new CounsellingAppointment()
				{
					SessionPreference = model.SessionPreference,
					BookingReasons = model.BookingReasons,
					ChallengesSpecific = model.ChallengesSpecific,
					PreferredDate = model.PreferredDate,
					PreferredTime = model.PreferredTime,
					PatientId = model.PatientId,
					PractitionerId = model.PractitionerId,
					SessionConfirmed = model.SessionConfirmed,
				};
				dbContext.tblCounsellingAppointment.Add(ca);
                dbContext.SaveChanges();
				TempData["CASuccessMessage"] = "Appointment for date: " + ca.PreferredDate + " successfully booked!";
				return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int? Id)
        {
            if(Id == null||Id == 0)
            {
                return NotFound();
            }
            var obj = new CounsellingAppointment();
            if (User.IsInRole(RoleConstants.Practitioner) || User.IsInRole(RoleConstants.Receptionist))
                obj = dbContext.tblCounsellingAppointment.Where(x => x.Id == Id && x.Archived == false).FirstOrDefault();
            else if (User.IsInRole(RoleConstants.Patient))
                obj = dbContext.tblCounsellingAppointment.Where(x => x.Id == Id && x.Archived == false && x.SessionConfirmed == false).FirstOrDefault();
            else if (User.IsInRole(RoleConstants.Admin))
                obj = dbContext.tblCounsellingAppointment.FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CounsellingAppointment model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var obj = dbContext.tblCounsellingAppointment.Where(va => va.Id == model.Id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }

            if (model.PreferredDate == null)
            {
                model.PreferredDate = obj.PreferredDate;
            }
            if (model.PreferredTime == null)
            {
                model.PreferredTime = obj.PreferredTime;
            }

            obj.Id = model.Id;
            obj.SessionPreference = model.SessionPreference;
            obj.BookingReasons = model.BookingReasons;
            obj.ChallengesSpecific = model.ChallengesSpecific;
            obj.PreferredDate = model.PreferredDate;
            obj.PreferredTime = model.PreferredTime;
            obj.PatientId = model.PatientId;
            obj.SessionConfirmed = model.SessionConfirmed;

            dbContext.tblCounsellingAppointment.Update(obj);
            dbContext.SaveChanges();
			TempData["CAUpdateSuccessMessage"] = "Appointment for date: " + obj.PreferredDate + " successfully updated!";
			return RedirectToAction("Index");
        }

        public IActionResult Details(int? Id)
        {
            var obj = dbContext.tblCounsellingAppointment.Where(x=>x.Id == Id).Include(x=>x.Patient).ThenInclude(x=>x.Users).Include(x=>x.Practitioner).ThenInclude(x=>x.Users).FirstOrDefault();
            if (obj == null)
                return View("PageNotFound", "Home");
            return View(obj);
        }

        public IActionResult Cancel(int? Id)
        {
            if(Id == 0 || Id == null)
            {
                return NotFound();
            }
            var obj = dbContext.tblCounsellingAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            var model = new ArchiveItemViewModel
            {
                Id = obj.Id,
                CounsAppointmentId = obj.Id,
                Archived = obj.Archived
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(ArchiveItemViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = dbContext.tblCounsellingAppointment.Where(va => va.Id == model.Id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }

            obj.Archived = model.Archived;

            dbContext.tblCounsellingAppointment.Update(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
