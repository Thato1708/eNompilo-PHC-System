using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Areas.Identity.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Models.Family_Planning;

namespace eNompilo.v3._0._1.Controllers
{
    public class FamilyPlanningAppointmentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public FamilyPlanningAppointmentController(ApplicationDbContext context)
        {
            dbContext = context;
            
        }
        public IActionResult Index()
        {
            IEnumerable<FamilyPlanningAppointment> objList = dbContext.tblFamilyPlanningAppointment;
            return View(objList);
        }

        public IActionResult Book()
        {
            var bookedAppointments = dbContext.tblFamilyPlanningAppointment
                .Select(a => new { a.PractitionerDiaryId, a.PreferredDate, a.PreferredTime })
                .ToList();

            ViewBag.BookedAppointments = bookedAppointments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(FamilyPlanningAppointment model)
        {
            if(ModelState.IsValid)
            {
                dbContext.tblFamilyPlanningAppointment.Add(model);
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
            var obj = dbContext.tblFamilyPlanningAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(FamilyPlanningAppointment model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblFamilyPlanningAppointment.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? Id)
        {
            var obj = dbContext.tblFamilyPlanningAppointment.Find(Id);
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
            var obj = dbContext.tblFamilyPlanningAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(FamilyPlanningAppointment model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblFamilyPlanningAppointment.Remove(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
