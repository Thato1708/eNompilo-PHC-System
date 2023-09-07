using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNompiloCounselling.Controllers
{
    public class GeneralAppointmentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public GeneralAppointmentController(ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            dbContext = context;
            _contextAccessor = contextAccessor;
        }
        public IActionResult Index()
        {
            var patientId = _contextAccessor.HttpContext.Session.GetInt32("PatientId");
            IEnumerable<GeneralAppointment> objList = dbContext.tblGeneralAppointment.Where(p=>p.Patient.Id == patientId).Include(p=>p.Patient).ToList();
			return View(objList);
        }

        public IActionResult Book()
        {
            var bookedAppointments = dbContext.tblGeneralAppointment
                .Select(a => new { a.PractitionerDiaryId, a.PreferredDate, a.PreferredTime })
                .ToList();

            ViewBag.BookedAppointments = bookedAppointments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(GeneralAppointment model)
        {
            if(model.PatientIssues != null && model.PreferredDate != null && model.PreferredTime != null && model.PatientId != null && model.PatientFileId != null)
            {
                dbContext.tblGeneralAppointment.Add(model);
                dbContext.SaveChanges();
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
            var obj = dbContext.tblGeneralAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(GeneralAppointment model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblGeneralAppointment.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? Id)
        {
            var obj = dbContext.tblGeneralAppointment.Find(Id);
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
            var obj = dbContext.tblGeneralAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(GeneralAppointment model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblGeneralAppointment.Remove(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
