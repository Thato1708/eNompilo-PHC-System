using Microsoft.AspNetCore.Mvc;
using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models.GBV;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using eNompilo.v3._0._1.Models.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eNompilo.v3._0._1.Controllers
{
    public class GbvRecommendationsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public GbvRecommendationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole(RoleConstants.Practitioner))
                {
                    IEnumerable<GbvRecommendations> objList = _context.tblRecommendations;
                    return View(objList);
                }
                else if (User.IsInRole(RoleConstants.Admin))
                {
                    IEnumerable<GbvRecommendations> objList = _context.tblRecommendations;
                    return View(objList);
                }

            }
            return NotFound();
        }




        public IActionResult Recommendations()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Recommendations(GbvRecommendations model)
        {
            if(model.PractitionerId !=  null && model.PatientId != null && model.Date != null && model.Reffered != null && model.PractitionerRecommendation != null)
            {
                _context.tblRecommendations.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        public IActionResult Details(int? Id)
        {
            var obj = _context.tblRecommendations.Find(Id);
            if (obj == null)
            {
                return View("PageNotFound", "Home");

            }
            return View(obj);
        }



        public IActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _context.tblRecommendations.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(GbvRecommendations model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            _context.tblRecommendations.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Cancel(int Id)
        {
            var obj = _context.tblRecommendations.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.tblRecommendations.Remove(obj);
            _context.SaveChanges(true);
            return RedirectToAction("Index");
        }




    }
}
