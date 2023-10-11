using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace eNompiloCounselling.Controllers
{
    public class PractitionerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext dbContext;

        public PractitionerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            dbContext = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            IEnumerable<Practitioner> objList = dbContext.tblPractitioner.Include(c=>c.Users);
            return View(objList);
        }

        public IActionResult PractitionerProfile(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblPractitioner.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
