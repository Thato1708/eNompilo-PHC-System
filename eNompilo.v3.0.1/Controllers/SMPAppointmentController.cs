using Microsoft.AspNetCore.Mvc;
using eNompilo.v3._0._1.Models.SMP;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.ViewModels;

namespace eNompilo.v3._0._1.Controllers
{
	public class SMPAppointmentController : Controller
	{
		private readonly ApplicationDbContext dbContext;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public SMPAppointmentController (ApplicationDbContext context,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			dbContext = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Index()
		{
			if (_signInManager.IsSignedIn(User))
			{
				if (User.IsInRole(RoleConstants.Patient))
				{
					IEnumerable<SMPAppointment> objList = dbContext.tblMedicalProcedureAppointment.Where(smpa => smpa.Archived == false).ToList();
					return View(objList);
				}
				else if (User.IsInRole(RoleConstants.Admin))
				{
					IEnumerable<SMPAppointment> objList = dbContext.tblMedicalProcedureAppointment;
					return View(objList);
				}
			}
			return NotFound();
		}

		public IActionResult SMPBookAppointment()
		{
			var bookedAppointment = dbContext.tblMedicalProcedureAppointment.Select(a => new { a.AnaesthesiaReaction, a.BreathingtubeSurgery, a.DiabetesQuestion, a.HeartAttack, a.HeartAttackDate, a.InsulinQuestion, a.Movement, a.NatureOfReaction }).ToList();

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
			{
				return View(model);
			}
			dbContext.tblMedicalProcedureAppointment.Update(model);
			dbContext.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete([FromRoute] int Id)
		{
			if (Id==0 || Id == null)
			{
				return NotFound();
			}
			var obj = dbContext.tblMedicalProcedureAppointment.Where(smpa => smpa.Id ==Id).FirstOrDefault();
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
	}
}
