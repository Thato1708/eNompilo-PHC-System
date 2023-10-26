using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNompilo.v3._0._1.Controllers
{
    public class CounsellingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public CounsellingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment, IHttpContextAccessor contextAccessor)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public IActionResult AdditionalResources()
        {
            IEnumerable<AddResources> objList = dbContext.tblAddResources;
            return View();
        }

        public IActionResult AddResources()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddResources(AddResources model)
        {
            if (model.ProfilePictureImageFile != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ProfilePictureImageFile.FileName);
                string ext = Path.GetExtension(model.ProfilePictureImageFile.FileName);
                model.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ext;
                string path = Path.Combine(wwwRootPath + "/img/uploads/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.ProfilePictureImageFile.CopyTo(fileStream);
                }
            }
            if (ModelState.IsValid)
            {
                dbContext.tblAddResources.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("AddMedicalHistory");
            }
            return View(model);
        }

        public IActionResult BreathingExercise()
        {
            return View();
        }

        public IActionResult MentalQuiz()
        {
            return View();
        }
    }
}
