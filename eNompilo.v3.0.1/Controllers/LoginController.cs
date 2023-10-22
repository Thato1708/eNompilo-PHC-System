using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using eNompilo.v3._0._1.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace eNompilo.v3._0._1.Controllers
{
	public class LoginController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _context;
		private readonly ILogger<RegisterController> _logger;
		private readonly IUserStore<ApplicationUser> _userStore;
		private readonly IUserEmailStore<ApplicationUser> _emailStore;
		private readonly IHttpContextAccessor _contextAccessor;

		public LoginController(UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, ILogger<RegisterController> logger, IHttpContextAccessor contextAccessor)
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
		public async Task<IActionResult> AppUser()
		{
			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> AppUser(LoginViewModel model, string? returnUrl = null)
		{

			if (ModelState.IsValid)
			{
				var user = _context.Users.Where(u => u.UserName == model.IdNumber).FirstOrDefault();
				var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
				int userTypeId = 0;
				if (result.Succeeded && user.Archived == false)
                {
                    _logger.LogInformation("User logged in.");
					if (user != null)
					{
						user.LastLogin = DateTime.UtcNow;
						_context.Users.Update(user);
						_context.SaveChanges();
					}
					if (user.UserRole == UserRole.Patient)
					{
						userTypeId = _context.tblPatient.Where(p => p.UserId == user.Id).FirstOrDefault().Id;
					}
					else if (user.UserRole == UserRole.Admin)
					{
						userTypeId = _context.tblAdmin.Where(p => p.UserId == user.Id).FirstOrDefault().Id;
					}
					else if (user.UserRole == UserRole.Practitioner)
					{
						userTypeId = _context.tblPractitioner.Where(p => p.UserId == user.Id).FirstOrDefault().Id;
					}
					else if (user.UserRole == UserRole.Receptionist)
					{
						userTypeId = _context.tblReceptionist.Where(p => p.UserId == user.Id).FirstOrDefault().Id;
					}
					else
					{
						userTypeId = 999;
					}

					if (string.IsNullOrEmpty(returnUrl) && user.UserRole == UserRole.Patient)
					{
						return RedirectToAction("Index", "Home");
					}
					else if (string.IsNullOrEmpty(returnUrl))
					{
						returnUrl = "/Users/UserProfile/" + userTypeId;
						return Redirect(returnUrl);
					}
					else
					{
						return Redirect(returnUrl);
					}
				}
				else if (result.Succeeded && user.Archived == true)
				{
					returnUrl = "/Login/BlockedUser/" + user.Id;
					await _signInManager.SignOutAsync();
					_logger.LogInformation("User logged out.");
					return Redirect(returnUrl);
				}
			}
			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			return View(model);
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult BlockedUser(string? Id)
		{
			if (Id == null || Id == "")
			{
				return NotFound();
			}
			var obj = _context.Users.Where(u => u.Id == Id).FirstOrDefault();
			if (obj == null)
			{
				return NotFound();
			}
			LoginViewModel model = new LoginViewModel()
			{
				UsersId = obj.Id,
				Users = obj
			};
			return View(model);
		}
	}
}