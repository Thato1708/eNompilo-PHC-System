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
using System.Composition;

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
			if (model.UserRole == UserRole.Admin)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.Admin.ProfilePictureImageFile.FileName);
				string fileName = model.FirstName.ToLower().ToString() + "_" + model.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.Admin.ProfilePictureImageFile.FileName);
				model.Admin.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "/img/uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.Admin.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}
			else if (model.UserRole == UserRole.Practitioner)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.Practitioner.ProfilePictureImageFile.FileName);
				string fileName = model.FirstName.ToLower().ToString() + "_" + model.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.Practitioner.ProfilePictureImageFile.FileName);
				model.Practitioner.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "/img/uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.Practitioner.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}
			else if (model.UserRole == UserRole.Receptionist)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.Receptionist.ProfilePictureImageFile.FileName);
				string fileName = model.FirstName.ToLower().ToString() + "_" + model.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.Receptionist.ProfilePictureImageFile.FileName);
				model.Receptionist.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "/img/uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.Receptionist.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}
			else if (model.UserRole == UserRole.Patient)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.Receptionist.ProfilePictureImageFile.FileName);
				string fileName = model.FirstName.ToLower().ToString() + "_" + model.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.PersonalDetails.ProfilePictureImageFile.FileName);
				model.PersonalDetails.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "/img/uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.PersonalDetails.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}

			//var rolesOptions = _context.UserRoles.ToList();
			//ViewBag.roleOptions = new SelectList(rolesOptions);

			model.AppUser.UserName = model.IdNumber;
			if (model.IdNumber != null && model.Titles != null && model.FirstName != null && model.LastName != null && model.PhoneNumber != null && model.Password != null && model.ConfirmPassword != null)
			{
				var result = await _userManager.CreateAsync(model.AppUser, model.Password);

				if (result.Succeeded)
				{
					if (model.UserRole == UserRole.Admin)
					{
						await _userManager.AddToRoleAsync(model.AppUser, RoleConstants.Admin);
						var admin = new Admin
						{
							UserId = model.Id,
							ProfilePicture = model.Admin.ProfilePicture,
							Gender = model.Admin.Gender,
							DOB = model.Admin.DOB,
							HomeTel = model.Admin.HomeTel,
							EmergencyPerson = model.Admin.EmergencyPerson,
							EmergenyContactNr = model.Admin.EmergenyContactNr,
							WorkTel = model.Admin.WorkTel,
							WorkEmail = model.Admin.WorkEmail,
							LineManager = model.Admin.LineManager,
							Citizenship = model.Admin.Citizenship,
							MaritalStatus = model.Admin.MaritalStatus,
							AddressLine1 = model.Admin.AddressLine1,
							AddressLine2 = model.Admin.AddressLine2,
							Suburb = model.Admin.Suburb,
							City = model.Admin.City,
							Province = model.Admin.Province,
							ZipCode = model.Admin.ZipCode,
							CreatedOn = model.CreatedOn,
							Archived = false,
						};
						_context.tblAdmin.Add(admin);
					}
					else if (model.UserRole == UserRole.Practitioner)
					{
						await _userManager.AddToRoleAsync(model.AppUser, RoleConstants.Practitioner);
						var practitioner = new Practitioner
						{
							UserId = model.Id,
							ProfilePicture = model.Practitioner.ProfilePicture,
							PractitionerType = model.Practitioner.PractitionerType,
							CounsellorType = model.Practitioner.CounsellorType,
							Gender = model.Practitioner.Gender,
							DOB = model.Practitioner.DOB,
							HomeTel = model.Practitioner.HomeTel,
							EmergencyPerson = model.Practitioner.EmergencyPerson,
							EmergenyContactNr = model.Practitioner.EmergenyContactNr,
							WorkTel = model.Practitioner.WorkTel,
							WorkEmail = model.Practitioner.WorkEmail,
							LineManager = model.Practitioner.LineManager,
							Citizenship = model.Practitioner.Citizenship,
							MaritalStatus = model.Practitioner.MaritalStatus,
							AddressLine1 = model.Practitioner.AddressLine1,
							AddressLine2 = model.Practitioner.AddressLine2,
							Suburb = model.Practitioner.Suburb,
							City = model.Practitioner.City,
							Province = model.Practitioner.Province,
							ZipCode = model.Practitioner.ZipCode,
							CreatedOn = model.CreatedOn,
							Archived = false,
						};
						_context.tblPractitioner.Add(practitioner);
					}
					else if (model.UserRole == UserRole.Receptionist)
					{
						await _userManager.AddToRoleAsync(model.AppUser, RoleConstants.Receptionist);

						var receptionist = new Receptionist
						{
							UserId = model.Id,
							ProfilePicture = model.Receptionist.ProfilePicture,
							CreatedOn = model.CreatedOn,
							Archived = false,
						};
						_context.tblReceptionist.Add(receptionist);
					}
					else if (model.UserRole == UserRole.Patient)
					{
						await _userManager.AddToRoleAsync(model.AppUser, RoleConstants.Patient);
						var patient = new Patient
						{
							UserId = model.Id,
							IdNumber = model.IdNumber,
							FirstName = model.FirstName,
							LastName = model.LastName,
							Email = model.Email,
							PhoneNumber = model.PhoneNumber,
							CreatedOn = model.CreatedOn,
							Archived = false,
						};
						_context.tblPatient.Add(patient);
						await _context.SaveChangesAsync();
						_logger.LogInformation("User created a new account with password");

						var patientVar = await _context.tblPatient.Where(p => p.UserId == model.Id).FirstOrDefaultAsync();
						int patientId = patientVar.Id;
						return await AddPersonalMedical(model);
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


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddPersonalMedical(UserTypeViewModel model)
		{
			var patient = _context.tblPatient.Where(p => p.Id == model.Patient.Id).FirstOrDefault();

			if(patient == null)
			{
				return NotFound();
			}

			var personalDetails = new PersonalDetails()
			{
				ProfilePicture = model.PersonalDetails.ProfilePicture,
				PatientId = patient.Id,
				Gender = model.PersonalDetails.Gender,
				DOB = model.PersonalDetails.DOB,
				Height = model.PersonalDetails.Height,
				Weight = model.PersonalDetails.Weight,
				BloodType = model.PersonalDetails.BloodType,
				HomeTel = model.PersonalDetails.HomeTel,
				EmergencyPerson = model.PersonalDetails.EmergencyPerson,
				EmergenyContactNr = model.PersonalDetails.EmergenyContactNr,
				Employed = model.PersonalDetails.Employed,
				WorkTel = model.PersonalDetails.WorkTel,
				WorkEmail = model.PersonalDetails.WorkEmail,
				Citizenship = model.PersonalDetails.Citizenship,
				MaritalStatus = model.PersonalDetails.MaritalStatus,
				AddressLine1 = model.PersonalDetails.AddressLine1,
				AddressLine2 = model.PersonalDetails.AddressLine2,
				Suburb = model.PersonalDetails.Suburb,
				City = model.PersonalDetails.City,
				Province = model.PersonalDetails.Province,
				ZipCode = model.PersonalDetails.ZipCode,
				Archived = false,
			};

			await _context.tblPersonalDetails.AddAsync(personalDetails);

			var medicalHistory = new MedicalHistory()
			{
				PatientId = patient.Id,
				PreviousDiagnoses = model.MedicalHistory.PreviousDiagnoses,
				PreviousMedication = model.MedicalHistory.PreviousMedication,
				GeneralAllergies = model.MedicalHistory.GeneralAllergies,
				MedicationAllergies = model.MedicalHistory.MedicationAllergies
			};

			await _context.tblMedicalHistory.AddAsync(medicalHistory);
			await _context.SaveChangesAsync();
			return CreatePatientFile(patient);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreatePatientFile(Patient patient)
		{
			var personalDetails = _context.tblPersonalDetails.Where(c => c.PatientId == patient.Id).FirstOrDefault();
			var personalDetailsId = personalDetails.Id;

			var medicalHistory = _context.tblMedicalHistory.Where(c => c.PatientId == patient.Id).FirstOrDefault();
			var medicalHistoryId = medicalHistory.Id;

			var patientName = patient.Titles + ". " + patient.FirstName + " " + patient.LastName;

			PatientFile model = new PatientFile()
			{
				PatientId = patient.Id,
				PersonalDetailsId = personalDetailsId,
				MedicalHistoryId = medicalHistoryId,
				Archived = false
			};

			_context.tblPatientFile.Add(model);
			_context.SaveChanges();

			TempData["SuccessMessage"] = "Congratulations " + patientName + "! You have been successfully registered as an eNompilo Patient and a file has been created for you.";

			return RedirectToAction(actionName: "Index", controllerName: "Home");
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