using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models.Vaccination;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using eNompilo.v3._0._1.Models.ViewModels;

namespace eNompilo.v3._0._1Controllers
{
    public class VaccinationAppointmentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public VaccinationAppointmentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
		{
            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole(RoleConstants.Patient) || User.IsInRole(RoleConstants.Receptionist))
                {
                    IEnumerable<VaccinationAppointment> objList = dbContext.tblVaccinationAppointment.Where(va=>va.Archived == false).Include(pr => pr.Practitioner).ThenInclude(u => u.Users).Include(p => p.Patient).ThenInclude(u => u.Users).ToList();
			        return View(objList);
                }
                else if (User.IsInRole(RoleConstants.Admin))
                {
                    IEnumerable<VaccinationAppointment> objList = dbContext.tblVaccinationAppointment.Include(pr => pr.Practitioner).ThenInclude(u => u.Users).Include(p => p.Patient).ThenInclude(u => u.Users);
			        return View(objList);
				}
				else if (User.IsInRole(RoleConstants.Practitioner))
				{
					IEnumerable<VaccinationAppointment> objList = dbContext.tblVaccinationAppointment.Where(va => va.Archived == false).Include(pr => pr.Practitioner).ThenInclude(u => u.Users).Include(p => p.Patient).ThenInclude(u => u.Users).ToList();
					return View(objList);
				}
			}
            return NotFound();
        }

        public IActionResult Book()
        {
            var bookedAppointments = dbContext.tblVaccinationAppointment
                .Select(a => new { a.PractitionerId, a.PreferredDate, a.PreferredTime })
                .ToList();

            ViewBag.BookedAppointments = bookedAppointments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(VaccinationAppointment model)
        {
            if(model.PreviousVaccine != null && model.VaccinableDiseases != null && model.PreferredDate != null && model.PreferredTime != null && model.PatientId != null)
			{
				VaccinationAppointment va = new VaccinationAppointment()
				{
					BeenVaccinated = model.BeenVaccinated,
					PreviousVaccine = model.PreviousVaccine,
					IsPregnant = model.IsPregnant,
					VaccinableDiseases = model.VaccinableDiseases,
					PreferredDate = model.PreferredDate,
					PreferredTime = model.PreferredTime,
					PatientId = model.PatientId,
					PractitionerId = model.PractitionerId,
					SessionConfirmed = model.SessionConfirmed,
				};
				dbContext.tblVaccinationAppointment.Add(va);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int? Id)
        {
            if(Id == null||Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblVaccinationAppointment.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(VaccinationAppointment model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            dbContext.tblVaccinationAppointment.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? Id)
        {
            var obj = dbContext.tblVaccinationAppointment.Where(x => x.Id == Id).Include(x => x.Patient).ThenInclude(x => x.Users).Include(x => x.Practitioner).ThenInclude(x => x.Users).FirstOrDefault();
            if (obj == null)
                return View("PageNotFound", "Home");
            return View(obj);
        }

        public IActionResult Cancel([FromRoute]int Id)
        {
            if(Id == 0 || Id == null)
            {
                return NotFound();
            }
            var obj = dbContext.tblVaccinationAppointment.Where(va => va.Id == Id).FirstOrDefault();
            if(obj == null)
            {
                return NotFound();
            }
            var model = new ArchiveItemViewModel
            {
                Id = obj.Id,
                VaxAppointmentId = obj.Id,
                Archived = obj.Archived
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(ArchiveItemViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = dbContext.tblVaccinationAppointment.Where(va => va.Id == model.Id).FirstOrDefault();

            if(obj == null)
            {
                return NotFound();
            }

            obj.Archived = model.Archived;

            dbContext.tblVaccinationAppointment.Update(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
