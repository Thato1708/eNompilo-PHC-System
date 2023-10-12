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
			//var rolesOptions = _context.Roles.ToList();
			//ViewBag.roleOptions = new SelectList(rolesOptions);
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
			if (model.UserRole == UserRole.Admin && model.ProfilePictureImageFile != null)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.ProfilePictureImageFile.FileName);
				string fileName = model.FirstName.ToLower().ToString() + "_" + model.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.ProfilePictureImageFile.FileName);
				model.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "/img/uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}
			else if (model.UserRole == UserRole.Practitioner && model.ProfilePictureImageFile != null)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.ProfilePictureImageFile.FileName);
				string fileName = model.FirstName.ToLower().ToString() + "_" + model.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.ProfilePictureImageFile.FileName);
				model.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "/img/uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}
			else if (model.UserRole == UserRole.Receptionist && model.ProfilePictureImageFile != null)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.ProfilePictureImageFile.FileName);
				string fileName = model.FirstName.ToLower().ToString() + "_" + model.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.ProfilePictureImageFile.FileName);
				model.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "/img/uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}
			else if (model.UserRole == UserRole.Patient && model.ProfilePictureImageFile != null)
			{
				string wwwRootPath = webHostEnvironment.WebRootPath;
				//string fileName = Path.GetFileNameWithoutExtension(model.ProfilePictureImageFile.FileName);
				string fileName = model.FirstName.ToLower().ToString() + "_" + model.LastName.ToLower().ToString();
				string ext = Path.GetExtension(model.ProfilePictureImageFile.FileName);
				model.ProfilePicture = fileName = fileName + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ext;
				string path = Path.Combine(wwwRootPath + "/img/uploads", fileName);
				using (var fileStream = new FileStream(path, FileMode.Create))
				{
					await model.ProfilePictureImageFile.CopyToAsync(fileStream);
				}
			}

			if (ModelState.IsValid)
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
					CreatedOn = model.CreatedOn,
					UserRole = model.UserRole,
					Archived = false,
				};

				var result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					if (model.UserRole == UserRole.Admin)
					{
						await _userManager.AddToRoleAsync(user, RoleConstants.Admin);
						var admin = new Admin
						{
							UserId = user.Id,
							ProfilePicture = model.ProfilePicture,
							Gender = model.Gender,
							DOB = model.DOB,
							HomeTel = model.HomeTel,
							EmergencyPerson = model.EmergencyPerson,
							EmergenyContactNr = model.EmergenyContactNr,
							WorkTel = model.WorkTel,
							WorkEmail = model.WorkEmail,
							LineManager = model.LineManager,
							Citizenship = model.Citizenship,
							MaritalStatus = model.MaritalStatus,
							AddressLine1 = model.AddressLine1,
							AddressLine2 = model.AddressLine2,
							Suburb = model.Suburb,
							City = model.City,
							Province = model.Province,
							ZipCode = model.ZipCode,
							CreatedOn = model.CreatedOn,
							Archived = false,
						};
						_context.tblAdmin.Add(admin);
					}
					else if (model.UserRole == UserRole.Practitioner)
					{
						await _userManager.AddToRoleAsync(user, RoleConstants.Practitioner);
						var practitioner = new Practitioner
						{
							UserId = user.Id,
							ProfilePicture = model.ProfilePicture,
							PractitionerType = model.PractitionerType,
							CounsellorType = model.CounsellorType,
							Gender = model.Gender,
							DOB = model.DOB,
							HomeTel = model.HomeTel,
							EmergencyPerson = model.EmergencyPerson,
							EmergenyContactNr = model.EmergenyContactNr,
							WorkTel = model.WorkTel,
							WorkEmail = model.WorkEmail,
							LineManager = model.LineManager,
							Citizenship = model.Citizenship,
							MaritalStatus = model.MaritalStatus,
							AddressLine1 = model.AddressLine1,
							AddressLine2 = model.AddressLine2,
							Suburb = model.Suburb,
							City = model.City,
							Province = model.Province,
							ZipCode = model.ZipCode,
							CreatedOn = model.CreatedOn,
							Archived = false,
						};
						_context.tblPractitioner.Add(practitioner);
					}
					else if (model.UserRole == UserRole.Receptionist)
					{
						await _userManager.AddToRoleAsync(user, RoleConstants.Receptionist);

						var receptionist = new Receptionist
						{
							UserId = user.Id,
							ProfilePicture = model.ProfilePicture,
                            Gender = model.Gender,
                            DOB = model.DOB,
                            HomeTel = model.HomeTel,
                            EmergencyPerson = model.EmergencyPerson,
                            EmergenyContactNr = model.EmergenyContactNr,
                            WorkTel = model.WorkTel,
                            WorkEmail = model.WorkEmail,
                            LineManager = model.LineManager,
                            Citizenship = model.Citizenship,
                            MaritalStatus = model.MaritalStatus,
                            AddressLine1 = model.AddressLine1,
                            AddressLine2 = model.AddressLine2,
                            Suburb = model.Suburb,
                            City = model.City,
                            Province = model.Province,
                            ZipCode = model.ZipCode,
                            CreatedOn = model.CreatedOn,
							Archived = false,
						};
						_context.tblReceptionist.Add(receptionist);
					}
					else if (model.UserRole == UserRole.Patient)
					{
						await _userManager.AddToRoleAsync(user, RoleConstants.Patient);
						var patient = new Patient
						{
							UserId = user.Id,
							IdNumber = model.IdNumber,
							FirstName = model.FirstName,
							LastName = model.LastName,
							Email = model.Email,
							PhoneNumber = model.PhoneNumber,
							CreatedOn = model.CreatedOn,
							Archived = false,
						};
						await _context.tblPatient.AddAsync(patient);
                        var output = await _context.SaveChangesAsync();

						if (output != null)
						{
							var patientVar = await _context.tblPatient.Where(p => p.UserId == user.Id).FirstOrDefaultAsync();

							var personalDetails = new PersonalDetails()
							{
								ProfilePicture = model.ProfilePicture,
								PatientId = patientVar.Id,
								Gender = model.Gender,
								DOB = model.DOB,
								Height = model.Height,
								Weight = model.Weight,
								BloodType = model.BloodType,
								HomeTel = model.HomeTel,
								EmergencyPerson = model.EmergencyPerson,
								EmergenyContactNr = model.EmergenyContactNr,
								Employed = model.Employed,
								WorkTel = model.WorkTel,
								WorkEmail = model.WorkEmail,
								Citizenship = model.Citizenship,
								MaritalStatus = model.MaritalStatus,
								AddressLine1 = model.AddressLine1,
								AddressLine2 = model.AddressLine2,
								Suburb = model.Suburb,
								City = model.City,
								Province = model.Province,
								ZipCode = model.ZipCode,
								Archived = false,
							};

							await _context.tblPersonalDetails.AddAsync(personalDetails);

							var medicalHistory = new MedicalHistory()
							{
								PatientId = patientVar.Id,
								PreviousDiagnoses = model.PreviousDiagnoses,
								PreviousMedication = model.PreviousMedication,
								GeneralAllergies = model.GeneralAllergies,
								MedicationAllergies = model.MedicationAllergies
							};

							await _context.tblMedicalHistory.AddAsync(medicalHistory);
							await _context.SaveChangesAsync();
						}
                        
						_logger.LogInformation("User created a new account with password");

                        return CreatePatientFile(patient);
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


		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> AddPersonalMedical(UserTypeViewModel model)
		//{
		//	int patientId = ViewBag.patientId;
		//	var patient = await _context.tblPatient.Where(p => p.Id == patientId).FirstOrDefaultAsync();

		//	if(patient == null)
		//	{
		//		return NotFound();
		//	}
		//}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreatePatientFile(Patient patient)
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
		var patient = _context.tblPatient.Where(p => p.Id == model.Id).FirstOrDefault();
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