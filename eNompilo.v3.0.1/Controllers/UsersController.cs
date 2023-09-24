using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using eNompilo.v3._0._1.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;

namespace eNompilo.v3._0._1.Controllers
{
	public class UsersController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _context;
		private readonly ILogger<RegisterController> _logger;
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IHttpContextAccessor _contextAccessor;

		public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, ILogger<RegisterController> logger, IWebHostEnvironment hostEnvironment, IHttpContextAccessor contextAccessor)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
			_logger = logger;
			webHostEnvironment = hostEnvironment;
			_contextAccessor = contextAccessor;
		}
		public IActionResult Index()
		{
			IEnumerable<ApplicationUser> objList = _context.Users.Where(u => u.Archived == true || u.Archived == false);
			return View(objList);
		}

		public IActionResult CreateUser()
		{
			return View();
		}

		//private IEnumerable<SelectListItem> GetSelectListItems()
		//{
		//    var selectList = new List<SelectListItem>();

		//    var enumValues = Enum.GetValues(typeof(UserRole)) as UserRole[];
		//    if(enumValues == null || enumValues.Length == 0)
		//    {
		//        return null;
		//    }
		//    foreach(var enumValue in enumValues) 
		//    {
		//        selectList.Add(new SelectListItem
		//        {
		//            Value = enumValue.ToString(),
		//            Text = enumValue.ToString()
		//        });
		//    }
		//    return selectList;
		//}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateUser(UserTypeViewModel model)
		{
			if (model.AppUser.UserRole == UserRole.Admin)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.Admin.ProfilePictureImageFile.FileName);
				string fileName = _userManager.GetUserAsync(User).Result.FirstName.ToLower().ToString() + "_" + _userManager.GetUserAsync(User).Result.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.Admin.ProfilePictureImageFile.FileName);
				model.Admin.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "\\img\\uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.Admin.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}
			else if (model.AppUser.UserRole == UserRole.Practitioner)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.Practitioner.ProfilePictureImageFile.FileName);
				string fileName = _userManager.GetUserAsync(User).Result.FirstName.ToLower().ToString() + "_" + _userManager.GetUserAsync(User).Result.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.Practitioner.ProfilePictureImageFile.FileName);
				model.Practitioner.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "\\img\\uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.Practitioner.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}
			else if (model.AppUser.UserRole == UserRole.Receptionist)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.Receptionist.ProfilePictureImageFile.FileName);
				string fileName = _userManager.GetUserAsync(User).Result.FirstName.ToLower().ToString() + "_" + _userManager.GetUserAsync(User).Result.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.Receptionist.ProfilePictureImageFile.FileName);
				model.Receptionist.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "\\img\\uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.Receptionist.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}

			model.AppUser.UserName = model.AppUser.IdNumber;
			if (model.AppUser.IdNumber != null && model.AppUser.Titles != null && model.AppUser.FirstName != null && model.AppUser.LastName != null && model.AppUser.PhoneNumber != null && model.AppUser.Password != null && model.AppUser.ConfirmPassword != null && model.AppUser.UserName != null && model.AppUser.Archived != null)
			{
				var result = await _userManager.CreateAsync(model.AppUser, model.AppUser.Password);

				if (result.Succeeded)
				{
					if (model.AppUser.UserRole == UserRole.Admin)
					{
						await _userManager.AddToRoleAsync(model.AppUser, RoleConstants.Admin);
						var admin = new Admin
						{
							UserId = model.AppUser.Id,
							ProfilePicture = model.Admin.ProfilePicture,
							CreatedOn = model.AppUser.CreatedOn,
							Archived = false,
						};
						_context.tblAdmin.Add(admin);
					}
					else if (model.AppUser.UserRole == UserRole.Practitioner)
					{
						await _userManager.AddToRoleAsync(model.AppUser, RoleConstants.Practitioner);
						var practitioner = new Practitioner
						{
							UserId = model.AppUser.Id,
							ProfilePicture = model.Practitioner.ProfilePicture,
							PractitionerType = model.Practitioner.PractitionerType,
							CounsellorType = model.Practitioner.CounsellorType,
							CreatedOn = model.AppUser.CreatedOn,
							Archived = false,
						};
						_context.tblPractitioner.Add(practitioner);
					}
					else if (model.AppUser.UserRole == UserRole.Patient)
					{
						await _userManager.AddToRoleAsync(model.AppUser, RoleConstants.Patient);
						var patient = new Patient
						{
							UserId = model.AppUser.Id,
							IdNumber = model.AppUser.IdNumber,
							FirstName = model.AppUser.FirstName,
							LastName = model.AppUser.LastName,
							Email = model.AppUser.Email,
							PhoneNumber = model.AppUser.PhoneNumber,
							CreatedOn = model.AppUser.CreatedOn,
							Archived = false,
						};
						_context.tblPatient.Add(patient);

						await _context.SaveChangesAsync();
						_logger.LogInformation("User created a new account with password");
						return RedirectToAction("AddPersonalDetails", "Patient", patient.Id);
					}
					else if (model.AppUser.UserRole == UserRole.Receptionist)
					{
						await _userManager.AddToRoleAsync(model.AppUser, RoleConstants.Receptionist);

						var receptionist = new Receptionist
						{
							UserId = model.AppUser.Id,
							ProfilePicture = model.Receptionist.ProfilePicture,
							CreatedOn = model.AppUser.CreatedOn,
							Archived = false,
						};
						_context.tblReceptionist.Add(receptionist);
					}

					await _context.SaveChangesAsync();
					_logger.LogInformation("User created a new account with password");
					return RedirectToAction("Index");
				}
				foreach (var error in result.Errors)
					ModelState.AddModelError(string.Empty, error.Description);
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult EditUser([FromRoute] string Id)
		{
			var user = _context.Users.Where(u => u.Id == Id).FirstOrDefault();

			if (user == null)
			{
				return NotFound();
			}

			var model = new EditUserViewModel
			{
				IdNumber = user.IdNumber,
				Titles = user.Titles,
				FirstName = user.FirstName,
				MiddleName = user.MiddleName,
				LastName = user.LastName,
				Email = user.Email,
				UserRole = user.UserRole,
				PhoneNumber = user.PhoneNumber,
				Archived = user.Archived,

			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditUser(EditUserViewModel model)
		{
			string? userId = HttpContext.Session.GetString("user_id");
			model.UserName = model.IdNumber;
			if (model.IdNumber != null && model.FirstName != null && model.LastName != null && model.PhoneNumber != null)
			{
				var user = await _context.Users.Where(u => u.Id == model.Id).FirstOrDefaultAsync();

				//int patientId = patient.Id;

				if (user == null)
				{
					return NotFound();
				}

				user.IdNumber = model.IdNumber;
				user.Titles = model.Titles;
				user.FirstName = model.FirstName;
				user.MiddleName = model.MiddleName;
				user.LastName = model.LastName;
				user.Email = model.Email;
				user.UserRole = model.UserRole;
				user.PhoneNumber = model.PhoneNumber;
				user.Archived = model.Archived;

				_context.Users.Update(user);
				await _context.SaveChangesAsync();

				var patient = await _context.tblPatient.Where(p => p.UserId == model.Id).FirstOrDefaultAsync();

				if (model.UserRole == UserRole.Patient)
					return EditPatient(patient.Id);
				else
					return RedirectToAction("Index");
			}
			return View(model);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditPatient([FromRoute] int? ID)
		{
			var patient = _context.tblPatient.Find(ID);
			var user = patient.Users;

			if (patient == null)
			{
				return NotFound();
			}

			patient.IdNumber = user.IdNumber;
			patient.Titles = user.Titles;
			patient.FirstName = user.FirstName;
			patient.MiddleName = user.MiddleName;
			patient.LastName = user.LastName;
			patient.Email = user.Email;
			patient.PhoneNumber = user.PhoneNumber;
			patient.Archived = user.Archived;
			

			_context.tblPatient.Update(patient);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}


		public IActionResult UserDetails([FromRoute] string? Id) //public IActionResult UserDetails([FromRoute] string Id)
		{
			var objUser = _context.Users.Where(u => u.Id == Id && (u.Archived == true || u.Archived == false)).FirstOrDefault();

			if (objUser == null)
				return NotFound();

			return View(objUser); //we didn't do the whole viewModel thingie, in case that comes back to bite us in the a**e
		}

		public IActionResult DeleteUser([FromRoute] string? Id) //public IActionResult DeleteUser([FromRoute] string Id)
		{
			if (Id == "" || Id == null)
				return NotFound();

			var obj = _context.Users.Where(u => u.Id == Id && (u.Archived == true || u.Archived == false)).FirstOrDefault();

			if (obj == null)
				return NotFound();

			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteUser(ApplicationUser model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			model.Archived = true;
			_context.Users.Update(model);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult UserProfile(int? Id)
		{
			if(_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Patient))
			{
				var patient = _context.tblPatient.Where(u => u.Id == Id).FirstOrDefault();
				if (patient == null)
					return NotFound();

				var model = new UserProfileViewModel
				{
					AppUserId = patient.UserId,
					PatientId = patient.Id
				};

				return View(model);

            }
			else if(_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Admin))
			{
				var admin = _context.tblAdmin.Where(u => u.Id == Id).FirstOrDefault();
                if (admin == null)
                    return NotFound();

                var model = new UserProfileViewModel
                {
					AppUserId = admin.UserId,
                    AdminId = admin.Id
                };

				return View(model);
            }
			else if(_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Practitioner))
			{
				var practitioner = _context.tblPractitioner.Where(u => u.Id == Id).FirstOrDefault();
                if (practitioner == null)
                    return NotFound();

                var model = new UserProfileViewModel
                {
					AppUserId = practitioner.UserId,
                    PractitionerId = practitioner.Id
                };

				return View(model);
            }
			else if(_signInManager.IsSignedIn(User) && User.IsInRole(RoleConstants.Receptionist))
			{
				var receptionist = _context.tblReceptionist.Where(u => u.Id == Id).FirstOrDefault();
                if (receptionist == null)
                    return NotFound();

                var model = new UserProfileViewModel
                {
					AppUserId = receptionist.UserId,
                    ReceptionistId = receptionist.Id
                };

				return View(model);
            }

			return NotFound();
;
		}
	}
}
/*
	if (model.UserRole == UserRole.Patient)
	{
		var patient = _context.tblPatient.Where(p => p.Id == model.Patient.Id).FirstOrDefault();
		patient.UserId = user.Id;
		patient.IdNumber = user.IdNumber;
		patient.Titles = user.Titles;
		patient.FirstName = user.FirstName;
		patient.MiddleName = user.MiddleName;
		patient.LastName = user.LastName;
		patient.Email = user.Email;
		patient.PhoneNumber = user.PhoneNumber;
		patient.Archived = user.Archived;

		_context.tblPatient.Update(patient);
	}
 */