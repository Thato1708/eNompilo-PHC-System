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
	public class GbvQuestionnaireController : Controller
	{
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public GbvQuestionnaireController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
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
                    IEnumerable<Questionnaire> objList = _context.tblQuestionnaire.Where(va => va.Archived == false).ToList();
                    return View (objList);
                }
                else if (User.IsInRole(RoleConstants.Admin))
                {
                    IEnumerable<Questionnaire> objList = _context.tblQuestionnaire;
                    return View(objList);

                }
            }
            return NotFound();
		}

       public IActionResult Questionnaire()
        {
            return View();
        }






	}
}
