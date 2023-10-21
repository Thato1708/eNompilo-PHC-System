using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using eNompilo.v3._0._1.Models.ViewModels;

namespace eNompiloCounselling.Controllers
{
    public class PractitionerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext dbContext;

        public PractitionerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            dbContext = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            IEnumerable<Practitioner> objList = dbContext.tblPractitioner.Include(c=>c.Users);
            return View(objList);
        }

        public IActionResult PractitionerProfile(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblPractitioner.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult PendingAppointments()
        {
            int practId = dbContext.tblPractitioner.Where(p=>p.UserId == _userManager.GetUserAsync(User).Result.Id).FirstOrDefault().Id;
            var model = new AppointmentsViewModel();
            model.GenAppointmentList = dbContext.tblGeneralAppointment.Where(ga => (ga.Archived == false && ga.SessionConfirmed == false) && (ga.PractitionerId == practId || ga.PractitionerId == null)).Include(p=>p.Patient).Include(pr=>pr.Practitioner).OrderBy(ga => ga.PreferredDate).OrderBy(ga => ga.PreferredTime).ToList();
            model.CounsAppointmentList = dbContext.tblCounsellingAppointment.Where(ga => (ga.Archived == false && ga.SessionConfirmed == false) && (ga.PractitionerId == practId || ga.PractitionerId == null)).Include(p => p.Patient).Include(pr=>pr.Practitioner).OrderBy(ga => ga.PreferredDate).OrderBy(ga => ga.PreferredTime).ToList();
            model.FPAppointmentList = dbContext.tblFamilyPlanningAppointment.Where(ga => (ga.Archived == false && ga.SessionConfirmed == false) && (ga.PractitionerId == practId || ga.PractitionerId == null)).Include(p => p.Patient).Include(pr=>pr.Practitioner).OrderBy(ga => ga.PreferredDate).OrderBy(ga => ga.PreferredTime).ToList();
            model.VaxAppointmentList = dbContext.tblVaccinationAppointment.Where(ga => (ga.Archived == false && ga.SessionConfirmed == false) && (ga.PractitionerId == practId || ga.PractitionerId == null)).Include(p => p.Patient).Include(pr=>pr.Practitioner).OrderBy(ga => ga.PreferredDate).OrderBy(ga => ga.PreferredTime).ToList();
            return View(model);
        }

        public IActionResult ConfirmGeneralAppointments(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblGeneralAppointment.Where(a => a.Id == Id).Include(p => p.Patient).ThenInclude(u => u.Users).Include(p => p.Practitioner).ThenInclude(u => u.Users).FirstOrDefault();
            if(obj == null)
            {
                return NotFound();
            }
            var model = new AppointmentsViewModel();
            model.Id = obj.Id;
            model.GenAppointmentId = obj.Id;
            model.PatientId = obj.PatientId;
            model.PractitionerId = obj.PractitionerId;
            model.SessionConfirmed = obj.SessionConfirmed;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmGeneralAppointments(AppointmentsViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = dbContext.tblGeneralAppointment.Where(va=>va.Id == model.Id).FirstOrDefault();

            if(obj == null)
            {
                return NotFound();
            }

            obj.PractitionerId = model.PractitionerId;
            obj.SessionConfirmed = model.SessionConfirmed;

            dbContext.tblGeneralAppointment.Update(obj);
            dbContext.SaveChanges();
            return RedirectToAction("PendingAppointments");
        }

        public IActionResult ConfirmCounsellingAppointments(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblCounsellingAppointment.Where(a=>a.Id == Id).Include(p=>p.Patient).ThenInclude(u=>u.Users).Include(p=>p.Practitioner).ThenInclude(u=>u.Users).FirstOrDefault();
            if(obj == null)
            {
                return NotFound();
            }
            var model = new AppointmentsViewModel();
			model.Id = obj.Id;
			model.CounsAppointmentId = obj.Id;
            model.PatientId = obj.PatientId;
            model.PractitionerId = obj.PractitionerId;
            model.SessionConfirmed = obj.SessionConfirmed;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmCounsellingAppointments(AppointmentsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = dbContext.tblCounsellingAppointment.Where(va => va.Id == model.Id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }

            obj.PractitionerId = model.PractitionerId;
            obj.SessionConfirmed = model.SessionConfirmed;

            dbContext.tblCounsellingAppointment.Update(obj);
            dbContext.SaveChanges();
            return RedirectToAction("PendingAppointments");
        }

        public IActionResult ConfirmFamilyPlanningAppointments(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblFamilyPlanningAppointment.Where(a => a.Id == Id).Include(p => p.Patient).ThenInclude(u => u.Users).Include(p => p.Practitioner).ThenInclude(u => u.Users).FirstOrDefault();
            if(obj == null)
            {
                return NotFound();
            }
            var model = new AppointmentsViewModel();
			model.Id = obj.Id;
			model.FPAppointmentId = obj.Id;
            model.PatientId = obj.PatientId;
            model.PractitionerId = obj.PractitionerId;
            model.SessionConfirmed = obj.SessionConfirmed;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmFamilyPlanningAppointments(AppointmentsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = dbContext.tblFamilyPlanningAppointment.Where(va => va.Id == model.Id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }

            obj.PractitionerId = model.PractitionerId;
            obj.SessionConfirmed = model.SessionConfirmed;

            dbContext.tblFamilyPlanningAppointment.Update(obj);
            dbContext.SaveChanges();
            return RedirectToAction("PendingAppointments");
        }

        public IActionResult ConfirmVaccinationAppointments(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblVaccinationAppointment.Where(a => a.Id == Id).Include(p => p.Patient).ThenInclude(u => u.Users).Include(p => p.Practitioner).ThenInclude(u => u.Users).FirstOrDefault();
            if(obj == null)
            {
                return NotFound();
            }
            var model = new AppointmentsViewModel();
			model.Id = obj.Id;
			model.VaxAppointmentId = obj.Id;
            model.PatientId = obj.PatientId;
            model.PractitionerId = obj.PractitionerId;
            model.SessionConfirmed = obj.SessionConfirmed;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmVaccinationAppointments(AppointmentsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = dbContext.tblVaccinationAppointment.Where(va => va.Id == model.Id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }

            obj.PractitionerId = model.PractitionerId;
            obj.SessionConfirmed = model.SessionConfirmed;

            dbContext.tblVaccinationAppointment.Update(obj);
            dbContext.SaveChanges();
            return RedirectToAction("PendingAppointments");
        }
    }
}
