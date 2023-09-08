using Microsoft.AspNetCore.Mvc;
using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Models.GBV;

namespace eNompilo.v3._0._1.Controllers
{
    public class ReportGBvController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportGBvController(ApplicationDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            IEnumerable<ReportGBV> objList = _context.tblReportGBV;
            return View(objList);
        }


        
        public IActionResult report()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult report(ReportGBV model)
        {
            if (model.PatientId != null && model.PatientFileId != null && model.Role != null && model.IdentityType != null && model.IncidentType != null && model.CommunicationType != null && model.CounsellingBooking != null)
            {
                _context.tblReportGBV.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }











    }
}
