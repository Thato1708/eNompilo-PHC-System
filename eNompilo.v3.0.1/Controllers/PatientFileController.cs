using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace eNompiloCounselling.Controllers
{
    public class PatientFileController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PatientFileController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<PatientFile> objList = dbContext.tblPatientFile;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PatientFile model)
        {
            if (ModelState.IsValid)
            {
                dbContext.tblPatientFile.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblPatientFile.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PatientFile model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblPatientFile.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblPatientFile.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
