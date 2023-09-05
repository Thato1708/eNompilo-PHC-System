using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Mvc;

namespace eNompiloCounselling.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PrescriptionController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<PrescriptionMeds> objList = dbContext.tblPrescriptionMeds;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PrescriptionMeds model)
        {
            if (ModelState.IsValid)
            {
                dbContext.tblPrescriptionMeds.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblPrescriptionMeds.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblPrescriptionMeds.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PrescriptionMeds model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblPrescriptionMeds.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblPrescriptionMeds.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(PrescriptionMeds model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblPrescriptionMeds.Remove(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
