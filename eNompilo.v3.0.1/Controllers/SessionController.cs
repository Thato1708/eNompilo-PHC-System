using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNompiloCounselling.Controllers
{
    public class SessionController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SessionController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Session> objList = dbContext.tblSession.Include(x=>x.Patient).Include(x=>x.Practitioner);
            return View(objList);
        }

        public IActionResult NewSession()
        {
            //Will (hopefully) display session notes into the session page below the Take Notes page.
            //Just reference the session notes bit
            return View();
        }

        public IActionResult Details(int? Id) 
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblSession.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult AddSessionNotes()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSessionNotes(SessionNotes model)
        {
            if (ModelState.IsValid)
            {
                dbContext.tblSessionNotes.Add(model);
                dbContext.SaveChanges();
                RedirectToAction("NewSession");
            }
            return View();
        }

        public IActionResult SessionNotesDetails(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblSessionNotes.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult EditSessionNotes(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblSessionNotes.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSessionNotes(SessionNotes model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblSessionNotes.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
