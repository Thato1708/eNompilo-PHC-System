using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models.Counselling;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Constants;
using System.Text.RegularExpressions;

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
            return View(objList);
        }

        public IActionResult AddResources()
        {
            return View();
        }
        public string GetYoutubeVideoId(string url)
        {
            var videoId = string.Empty;
            var regex = new Regex(@"youtu(?:\.be\/|be\.com\/watch\?v=|\.com\/)([\w-]{11})", RegexOptions.IgnoreCase);
            var match = regex.Match(url);
            if (match.Success)
            {
                videoId = match.Groups[1].Value;
            }
            return videoId;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddResources(AddResources model)
        {
            if (model.ImageFile != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string ext = Path.GetExtension(model.ImageFile.FileName);
                model.ImageName = fileName = fileName + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ext;
                string path = Path.Combine(wwwRootPath + "/img/uploads/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }
            if (model.ImageName != null && model.Title != null && model.Description != null && model.YoutubeLink != null)
            {
                var videoId = GetYoutubeVideoId(model.YoutubeLink);
                var embedUrl = $"https://www.youtube.com/embed/{videoId}";
                var obj = new AddResources
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageName = model.ImageName,
                    YoutubeLink = embedUrl,
                };

                dbContext.tblAddResources.Add(obj);
                dbContext.SaveChanges();
                return RedirectToAction("AdditionalResources");
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
