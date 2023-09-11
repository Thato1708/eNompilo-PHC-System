using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using eNompilo.v3._0._1.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace eNompiloCounselling.Controllers
{
    public class PatientController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public PatientController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment, IHttpContextAccessor contextAccessor)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public IActionResult Index()
        {
            IEnumerable<Patient> objList = dbContext.tblPatient;
            return View(objList);
        }

        //public IActionResult EditPatient(int? Id)
        //{
        //    if(Id == null || Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = dbContext.tblPatient.Find(Id);
        //    if(obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}

        //public async Task<IActionResult> EditPatient(Patient model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    dbContext.tblPatient.Update(model);
        //    dbContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public IActionResult PatientProfile(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblPatient.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult PatientDashboard()
        {
            var patientId = _contextAccessor.HttpContext.Session.GetInt32("PatientId");
            var patientFile = dbContext.tblPatientFile.Where(x => x.PatientId == patientId).Include(md => md.MedicalHistory).FirstOrDefault();
            var generalAppointment = dbContext.tblGeneralAppointment.Where(p => p.PatientId == patientId).Include(p => p.Patient).ToList();
            var prescription = dbContext.tblSession.Where(x => x.PatientId == patientId).Include(x => x.Patient).ToList();


            var personalDetails = dbContext.tblPersonalDetails.SingleOrDefault(c => c.PatientId == patientId);
            var personalDetailsId = personalDetails.Id;

            var sessionNotes = dbContext.tblSessionNotes.SingleOrDefault();

            //var condition = dbContext.tblSessionNotes.Where(x => x.Id).ToList();


            PatientDashboardViewModel patientDashboard = new PatientDashboardViewModel()
            {
                PatientFiles = patientFile,
                GeneralAppointments = generalAppointment,
                Medication = prescription,
                //Session = condition
            };
            return View(patientDashboard);
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AddPersonalDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPersonalDetails(PersonalDetails model)
        {
            if (model.ProfilePictureImageFile != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ProfilePictureImageFile.FileName);
                string ext = Path.GetExtension(model.ProfilePictureImageFile.FileName);
                model.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ext;
                string path = Path.Combine(wwwRootPath + "/img/uploads/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.ProfilePictureImageFile.CopyTo(fileStream);
                }
            }
            if (model.PatientId != null && model.Gender != null && model.DOB != null && model.EmergencyPerson != null && model.EmergenyContactNr != null && model.Employed != null && model.Citizenship != null && model.MaritalStatus != null && model.AddressLine1 != null && model.City != null && model.Province != null && model.ZipCode != null)
            {
                dbContext.tblPersonalDetails.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("AddMedicalHistory");
            }
            return View(model);
        }

        public IActionResult EditPersonalDetails(int? Id) //View Not created due to image update issue
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblPersonalDetails.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPersonalDetails(PersonalDetails model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblPersonalDetails.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddMedicalHistory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMedicalHistory(MedicalHistory model)
        {
            if (model.PatientId != null && model.PreviousDiagnoses != null && model.PreviousMedication != null && model.GeneralAllergies != null && model.MedicationAllergies != null) //model state was not returning valid.
            {
                dbContext.tblMedicalHistory.Add(model);
                dbContext.SaveChanges();

                return CreatePatientFile();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePatientFile()
        {
            var patientId = _contextAccessor.HttpContext.Session.GetInt32("PatientId");

            if (_contextAccessor.HttpContext.Session.GetInt32("PatientId2") == null)
            {
                patientId = _contextAccessor.HttpContext.Session.GetInt32("PatientId");
            }
            else if (_contextAccessor.HttpContext.Session.GetInt32("PatientId") == null)
            {
                patientId = _contextAccessor.HttpContext.Session.GetInt32("PatientId2");
            }

            var personalDetails = dbContext.tblPersonalDetails.SingleOrDefault(c => c.PatientId == patientId);
            var personalDetailsId = personalDetails.Id;

            var medicalHistory = dbContext.tblMedicalHistory.SingleOrDefault(c => c.PatientId == patientId);
            var medicalHistoryId = medicalHistory.Id;

            int? truePatientId = patientId;

            if (_contextAccessor.HttpContext.Session.GetInt32("PatientId2") == null)
            {
                truePatientId = _contextAccessor.HttpContext.Session.GetInt32("PatientId");
            }
            else if (_contextAccessor.HttpContext.Session.GetInt32("PatientId") == null)
            {
                truePatientId = _contextAccessor.HttpContext.Session.GetInt32("PatientId2");
            }

            //@UserManager.GetUserAsync(User).Result.FirstName @UserManager.GetUserAsync(User).Result.LastName

            var patientName = _userManager.GetUserAsync(User).Result.Titles + ". " + _userManager.GetUserAsync(User).Result.FirstName + " " + _userManager.GetUserAsync(User).Result.LastName.ToString();

            PatientFile model = new PatientFile()
            {
                PatientId = truePatientId,
                PersonalDetailsId = personalDetailsId,
                MedicalHistoryId = medicalHistoryId,
                Archived = false
            };

            dbContext.tblPatientFile.Add(model);
            dbContext.SaveChanges();

            TempData["SuccessMessage"] = "Congratulations " + patientName + "! You have been successfully registered as an eNompilo Patient and a file has been created for you.";

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult EditMedicalHistory(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblMedicalHistory.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMedicalHistory(MedicalHistory model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblMedicalHistory.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
