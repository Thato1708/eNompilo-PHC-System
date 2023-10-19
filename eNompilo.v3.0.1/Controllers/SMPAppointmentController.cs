using Microsoft.AspNetCore.Mvc;
using eNompilo.v3._0._1.Models.SMP;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.ViewModels;
using eNompilo.v3._0._1.Models;

namespace eNompilo.v3._0._1.Controllers
{
	public class SMPAppointmentController : Controller
	{
		private readonly ApplicationDbContext dbContext;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public SMPAppointmentController (ApplicationDbContext context,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			dbContext = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Index()
		{

			var patientId = 0; if (User.IsInRole(RoleConstants.Patient)) { patientId = dbContext.tblPatient.Where(p => p.UserId == _userManager.GetUserAsync(User).Result.Id).FirstOrDefault().Id; }
            IEnumerable<SMPAppointment> objList = dbContext.tblMedicalProcedureAppointment.Include(pr => pr.Practitioner).ThenInclude(u => u.Users).Include(p => p.Patient).ThenInclude(u => u.Users);
            //if (_signInManager.IsSignedIn(User))
            //{
            //	if (User.IsInRole(RoleConstants.Patient))
            //	{
            //		IEnumerable<SMPAppointment> objList = dbContext.tblMedicalProcedureAppointment.Where(smpa => smpa.Archived == false).ToList();
            //		return View(objList);
            //	}
            //	else if (User.IsInRole(RoleConstants.Admin))
            //	{
            //		IEnumerable<SMPAppointment> objList = dbContext.tblMedicalProcedureAppointment;
            //		return View(objList);
            //	}
            //	else if (User.IsInRole(RoleConstants.Practitioner))
            //	{
            //                 IEnumerable<SMPAppointment> objList = dbContext.tblMedicalProcedureAppointment;
            //                 return View(objList);
            //             }
            //}
            return View(objList);
		}

		public IActionResult SMPBookAppointment()
		{
			var bookedAppointment = dbContext.tblMedicalProcedureAppointment
				.Select(a => new { a.AnaesthesiaReaction, a.BreathingtubeSurgery, a.DiabetesQuestion,
					a.HeartAttack, a.HeartAttackDate, a.InsulinQuestion, a.Movement, a.NatureOfReaction }).ToList();

			ViewBag.BookedAppointments = bookedAppointment;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult SMPBookAppointment(SMPAppointment model)
		{
			if (ModelState.IsValid)
			{
				dbContext.tblMedicalProcedureAppointment.Add(model);
				dbContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(model);
		}

		public IActionResult Update(int? Id)
		{
			if (Id == null || Id == 0)
			{
				return NotFound();
			}
			var obj = dbContext.tblMedicalProcedureAppointment.Find(Id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Update(SMPAppointment model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var obj = dbContext.tblMedicalProcedureAppointment.Where(va => va.Id == model.Id).FirstOrDefault();

			if (obj == null)
			{
				return NotFound();
			}

			if (model.PreferredDate == null)
			{
				model.PreferredDate = obj.PreferredDate;
			}
			if (model.PreferredTime == null)
			{
				model.PreferredTime = obj.PreferredTime;
			}

			obj.Id = model.Id;
			obj.AnaesthesiaReaction = model.AnaesthesiaReaction;
			obj.NatureOfReaction = model.NatureOfReaction;
			obj.PreferredDate = model.PreferredDate;
			obj.PreferredTime = model.PreferredTime;
			obj.BreathingtubeSurgery= model.BreathingtubeSurgery;
			obj.HeartAttack= model.HeartAttack;
			obj.HeartAttackDate= model.HeartAttackDate;
			obj.InsulinQuestion= model.InsulinQuestion;
			obj.Movement=model.Movement;
			if (obj.PractitionerId != null)
				obj.SessionConfirmed= true;
			
			dbContext.tblMedicalProcedureAppointment.Update(model);
			dbContext.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int?Id)
		{
			if (Id==0 || Id == null)
			{
				return NotFound();
			}
			var obj = dbContext.tblMedicalProcedureAppointment.Find(Id);
			if (obj == null)
			{
				return NotFound();
			}
			var model = new ArchiveItemViewModel
			{
				Id = obj.Id,
				ProcedureAppointmentId = obj.Id,
				Archived = obj.Archived
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Delete(ArchiveItemViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var obj = dbContext.tblMedicalProcedureAppointment.Where(smpa => smpa.Id == model.Id).FirstOrDefault();

			if (obj == null)
			{
				return NotFound();
			}

			obj.Archived = model.Archived;

			dbContext.tblMedicalProcedureAppointment.Update(obj);
			dbContext.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Details(int? Id)
		{
			var obj = dbContext.tblMedicalProcedureAppointment.Find(Id);
			if (obj == null)
			{
				return View("PageNotFound", "Home");

			}
			return View(obj);
		}
	}
}
