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
            return View();
        }











    }
}
