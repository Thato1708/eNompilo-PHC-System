using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNompiloCounselling.Controllers
{
    [Authorize]
    public class CounsellingAppointmentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CounsellingAppointmentController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
		{
            IEnumerable<CounsellingAppointment> objList = dbContext.tblCounsellingAppointment;
			return View(objList);
        }

        public IActionResult Book()
        {
            var bookedAppointments = dbContext.tblCounsellingAppointment
                .Select(a => new { a.PractitionerDiaryId, a.PreferredDate, a.PreferredTime })
                .ToList();

            ViewBag.BookedAppointments = bookedAppointments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(CounsellingAppointment model)
        {
            if(ModelState.IsValid)
            {
                dbContext.tblCounsellingAppointment.Add(model);
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
            var obj = dbContext.tblCounsellingAppointment.Find(Id);
            if(obj == null)
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
            dbContext.tblCounsellingAppointment.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? Id)
        {
            var obj = dbContext.tblCounsellingAppointment.Find(Id);
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
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(CounsellingAppointment model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblCounsellingAppointment.Remove(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
