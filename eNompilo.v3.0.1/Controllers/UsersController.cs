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

namespace eNompilo.v3._0._1.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RegisterController> _logger;
		private readonly IWebHostEnvironment webHostEnvironment;

		public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, ILogger<RegisterController> logger, IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;
			webHostEnvironment = hostEnvironment;
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
            else  if (model.AppUser.UserRole == UserRole.Receptionist)
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
                PhoneNumber = user.PhoneNumber,
                Archived = user.Archived,

            };
            return View(model); //we didn't do the whole viewModel thingie, in case that comes back to bite us in the a**e
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            model.UserName = model.IdNumber;
            if (model.IdNumber != null && model.FirstName != null && model.LastName != null && model.PhoneNumber != null)
            {
                var user = _context.Users.Where(u => u.Id == model.Id).FirstOrDefault();
                var obj = _context.tblPatient.Where(u => u.Id == model.Patient.Id).FirstOrDefault();

                if(user == null)
                {
                    return NotFound();
                }

                if(obj == null)
                {
                    return NotFound();
                }

                user.IdNumber = model.IdNumber;
                user.Titles = model.Titles;
                user.FirstName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Archived = model.Archived;

                obj.IdNumber = model.IdNumber;
                obj.FirstName = model.FirstName;
				obj.MiddleName = model.MiddleName;
				obj.LastName = model.LastName;
                obj.Email = model.Email;
                obj.PhoneNumber = model.PhoneNumber;
                obj.Archived = model.Archived;

                _context.Users.Update(user);
                _context.tblPatient.Update(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UserDetails([FromRoute] string Id) //public IActionResult UserDetails([FromRoute] string Id)
        {
            var objUser = _context.Users.Where(u => u.Id == Id && (u.Archived == true || u.Archived == false)).FirstOrDefault();

            if (objUser == null)
                return NotFound();

            return View(objUser); //we didn't do the whole viewModel thingie, in case that comes back to bite us in the a**e
        }

        public IActionResult DeleteUser([FromRoute] string Id) //public IActionResult DeleteUser([FromRoute] string Id)
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
            _context.Users.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UserProfile([FromRoute]string Id)
        {
            if (Id == "" || Id == null)
                return NotFound();

            var obj = _context.Users.Where(u => u.Id == Id).FirstOrDefault();
            var obj2 = _context.tblPatientFile.Where(u => u.Patient.UserId == Id).FirstOrDefault();
            var obj3 = _context.tblAdmin.Where(u => u.Users.Id == Id).FirstOrDefault();
            var obj4 = _context.tblPractitioner.Where(u => u.Users.Id == Id).FirstOrDefault();
            var obj5 = _context.tblReceptionist.Where(u => u.Users.Id == Id).FirstOrDefault();

            if (obj == null || obj2 == null || obj3 == null || obj4 == null || obj5 == null)
                return NotFound();

            var model = new UserProfileViewModel
            {
                AppUserId = Id,
                PatientId = obj2.Id,
                AdminId = obj3.Id,
                PractitionerId = obj4.Id,
                ReceptionistId = obj5.Id
            };
            return View(model);
        }
    } 
}
