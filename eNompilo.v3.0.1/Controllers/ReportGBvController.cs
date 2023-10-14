using Microsoft.AspNetCore.Mvc;
using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models.GBV;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using eNompilo.v3._0._1.Models.ViewModels;

namespace eNompilo.v3._0._1.Controllers
{
    public class ReportGBvController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ReportGBvController(ApplicationDbContext context ,UserManager<ApplicationUser>userManager,SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole(RoleConstants.Patient))
                {
                    IEnumerable<ReportGBV> objList = _context.tblReportGBV.Where(va => va.Archived == false).ToList();
                    return View(objList);
                }
                else if (User.IsInRole(RoleConstants.Admin))
                {
                    IEnumerable<ReportGBV> objList = _context.tblReportGBV;
                    return View(objList);
                }
            }
            return NotFound();
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
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int ?Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _context.tblReportGBV.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ReportGBV model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            _context.tblReportGBV.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? Id)
        {
            var obj = _context.tblReportGBV.Find(Id);
            if (obj == null)
                return View("PageNotFound", "Home");
            return View(obj);
        }

        public IActionResult Cancel(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _context.tblReportGBV.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(ReportGBV model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            _context.tblReportGBV.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



















    }
}
