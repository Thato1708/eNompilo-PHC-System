using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNompiloCounselling.Controllers
{
    public class PractitionerDiaryController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext dbContext;

        public PractitionerDiaryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            dbContext = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            IEnumerable<PractitionerDiary> objList = dbContext.tblPractitionerDiary; //Lists all pending appointments practitoner has
            return View(objList);
        }

        public IActionResult PratitionerDiaryEntry()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PratitionerDiaryEntry(PractitionerDiary model)
        {
            if (ModelState.IsValid)
            {
                dbContext.tblPractitionerDiary.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //public IActionResult Update(int? Id)
        //{
        //    if (Id == null || Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = dbContext.tblAppointment.Find(Id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(Appointment model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    dbContext.tblAppointment.Update(model);
        //    dbContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Details(int? Id)
        //{
        //    var obj = dbContext.tblAppointment.Find(Id);
        //    if (obj == null)
        //        return View("PageNotFound", "Home");
        //    return View(obj);
        //}

        //public IActionResult Cancel(int? Id)
        //{
        //    if (Id == 0 || Id == null)
        //    {
        //        return NotFound();
        //    }
        //    var obj = dbContext.tblAppointment.Find(Id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Cancel(Appointment model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    dbContext.tblAppointment.Remove(model);
        //    dbContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
