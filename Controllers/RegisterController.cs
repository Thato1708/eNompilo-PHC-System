using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace eNompilo.v3._0._1.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _context;
		private readonly ILogger<RegisterController> _logger;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
		private readonly IHttpContextAccessor _contextAccessor;

        public RegisterController(UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, ILogger<RegisterController> logger, IHttpContextAccessor contextAccessor)
		{
			_userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
			_context = context;
			_logger = logger;
			_contextAccessor = contextAccessor;
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Admin()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Admin(ApplicationUser model)
		{
			model.UserName = model.IdNumber;
			if(ModelState.IsValid)
            {
                await _userStore.SetUserNameAsync(model, model.IdNumber, CancellationToken.None);
                var result = await _userManager.CreateAsync(model, model.Password);
				if(result.Succeeded)
				{
					await _userManager.AddToRoleAsync(model, RoleConstants.Admin);
					await _context.SaveChangesAsync();
					_logger.LogInformation("User Created a new account with password");
					await _signInManager.SignInAsync(model, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}

				foreach(var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(model);
		}

		//[AllowAnonymous]
		//[HttpGet]
		//public IActionResult Practitioner()
		//{
		//	return View();
		//}

		//[AllowAnonymous]
		//[HttpPost]
		//public async Task<IActionResult> Practitioner(ApplicationUser model)
		//{
		//	model.UserName = model.IdNumber;
		//	if(ModelState.IsValid)
		//	{
		//		var result = await _userManager.CreateAsync(model, model.Password);
		//		if(result.Succeeded)
		//		{
		//			await _userManager.AddToRoleAsync(model, RoleConstants.Practitioner);
		//			await _context.SaveChangesAsync();
		//			_logger.LogInformation("User Created a new account with password");
		//			await _signInManager.SignInAsync(model, isPersistent: false);
		//			return RedirectToAction("Index", "Practitioner");
		//		}

		//		foreach(var error in result.Errors)
		//		{
		//			ModelState.AddModelError(string.Empty, error.Description);
		//		}
		//	}

		//	return View(model);
		//}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Patient()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Patient(ApplicationUser model)
		{
			if(ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = model.IdNumber,
					IdNumber = model.IdNumber,
					Titles = model.Titles,
					FirstName = model.FirstName,
					MiddleName = model.MiddleName,
					LastName = model.LastName,
					Email = model.Email,
					PhoneNumber = model.PhoneNumber,
					Password = model.Password,
					ConfirmPassword = model.ConfirmPassword,
					UserRole = UserRole.Patient,
				};

				var result = await _userManager.CreateAsync(user, model.Password);
				if(result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, RoleConstants.Patient);

					var patient = new Patient
					{
						UserId = user.Id,
						IdNumber= model.IdNumber,
                        Titles = model.Titles,
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
						Email = model.Email,
						PhoneNumber = model.PhoneNumber,
						CreatedOn = model.CreatedOn,
						Archived = false,
					};
					_context.tblPatient.Add(patient);
					await _context.SaveChangesAsync();
					await _signInManager.SignInAsync(user, isPersistent: false);
					_logger.LogInformation("User created a new account with password.");
					_contextAccessor.HttpContext.Session.SetInt32("PatientId2", patient.Id);
					return RedirectToAction("AddPersonalDetails", "Patient");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View(model);
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult Receptionist()
        //{
        //    return View();
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Receptionist(ApplicationUser model)
        //{
        //    model.UserName = model.IdNumber;
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _userManager.CreateAsync(model, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(model, RoleConstants.Receptionist);
        //            await _context.SaveChangesAsync();
        //            _logger.LogInformation("User Created a new account with password");
        //            await _signInManager.SignInAsync(model, isPersistent: false);
        //            return RedirectToAction("Index", "Receptionist");
        //        }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }

        //    return View(model);
        //}
    }
}
