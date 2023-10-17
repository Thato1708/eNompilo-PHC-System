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
    public class GbvSupportController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public GbvSupportController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            if(_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole(RoleConstants.Patient))
                {
                    IEnumerable<SupportMembership> objList = _context.tblSupportGroup;
                    return View(objList);
                }
                else if (User.IsInRole(RoleConstants.Admin))
                {
                    IEnumerable<SupportMembership> objList = _context.tblSupportGroup;
                    return View(objList);
                }

            }
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupportMembership model)
        {
            if(model.Name != null  && model.Surname != null && model.Cell != null && model.Email !=null && model.gender != null && model.Reported != null)
            {
                _context.tblSupportGroup.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        
        
        


    }
}
