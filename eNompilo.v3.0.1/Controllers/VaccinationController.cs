using Microsoft.AspNetCore.Mvc;

namespace eNompilo.v3._0._1.Controllers
{
    public class VaccinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DoseTracking()
        {
            return View();
        }

        public IActionResult VaccinationInventory()
        {
            return View();
        }

        public IActionResult PrivacyandSecurity()
        {
            return View();
        }
    }
}
