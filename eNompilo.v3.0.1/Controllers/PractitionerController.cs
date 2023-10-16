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
            var model = new AppointmentsViewModel();
            model.GenAppointment = dbContext.tblGeneralAppointment.Where(ga => ga.Archived == false && ga.SessionConfirmed == false).Include(p=>p.Patient).Include(pr=>pr.Practitioner).ToList();
            model.CounsAppointment = dbContext.tblCounsellingAppointment.Include(p => p.Patient).ToList();
            model.FPAppointment = dbContext.tblFamilyPlanningAppointment.Include(p => p.Patient).ToList();
            model.VaxAppointment = dbContext.tblVaccinationAppointment.Include(p => p.Patient).ToList();
            return View(model);
        }

        public IActionResult ConfirmGeneralAppointments(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblGeneralAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult ConfirmCounsellingAppointments(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblCounsellingAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult ConfirmFamilyPlanningAppointments(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblFamilyPlanningAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult ConfirmVaccinationAppointments(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblVaccinationAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
	}
}
