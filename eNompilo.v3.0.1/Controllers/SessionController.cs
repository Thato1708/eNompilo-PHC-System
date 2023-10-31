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

        [HttpPost]
        public IActionResult NewSession(Session model)
        {
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
    }
}
