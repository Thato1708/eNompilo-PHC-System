using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models.Vaccination;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNompiloCounselling.Controllers
{
    public class VaccinationAppointmentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public VaccinationAppointmentController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
		{
            IEnumerable<VaccinationAppointment> objList = dbContext.tblVaccinationAppointment;
			return View(objList);
        }

        public IActionResult Book()
        {
            var bookedAppointments = dbContext.tblVaccinationAppointment
                .Select(a => new { a.PractitionerDiaryId, a.PreferredDate, a.PreferredTime })
                .ToList();

            ViewBag.BookedAppointments = bookedAppointments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(VaccinationAppointment model)
        {
            if(ModelState.IsValid)
            {
                dbContext.tblVaccinationAppointment.Add(model);
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
            var obj = dbContext.tblVaccinationAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(VaccinationAppointment model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblVaccinationAppointment.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? Id)
        {
            var obj = dbContext.tblVaccinationAppointment.Find(Id);
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
            var obj = dbContext.tblVaccinationAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(VaccinationAppointment model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblVaccinationAppointment.Remove(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
