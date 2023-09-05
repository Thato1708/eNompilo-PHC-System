using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Areas.Identity.Data;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Controllers;

namespace eNompilo.v3._0._1.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RegisterController> _logger;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, ILogger<RegisterController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(ApplicationUser model)
        {
            model.UserName = model.IdNumber;
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(model, model.Password);

                if (result.Succeeded)
                {
                    if (model.UserRole == UserRole.Admin)
                    {
                        await _userManager.AddToRoleAsync(model, RoleConstants.Admin);
                        var admin = new Admin
                        {
                            UserId = model.Id,
                            CreatedOn = model.CreatedOn,
                            Archived = false,
                        };
                        _context.tblAdmin.Add(admin);
                    }
                    else if (model.UserRole == UserRole.Practitioner)
                    {
                        await _userManager.AddToRoleAsync(model, RoleConstants.Practitioner);
                        var practitioner = new Practitioner
                        {
                            UserId = model.Id,
                            CreatedOn = model.CreatedOn,
                            Archived = false,
                        };
                        _context.tblPractitioner.Add(practitioner);
                    }
                    else if (model.UserRole == UserRole.Patient)
                    {
                        await _userManager.AddToRoleAsync(model, RoleConstants.Patient);
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
                        return RedirectToAction("AddPersonalDetails", "Patient", patient.Id);
                    }
                    else if (model.UserRole == UserRole.Receptionist)
                    {
                        await _userManager.AddToRoleAsync(model, RoleConstants.Receptionist);

                        var receptionist = new Receptionist
                        {
                            UserId = model.Id,
                            CreatedOn = model.CreatedOn,
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

        public IActionResult EditUser([FromRoute] string Id)
        {
            var objUser = _context.Users.Where(u => u.Id == Id && (u.Archived == true || u.Archived == false)).FirstOrDefault();

            if (objUser == null)
                return NotFound();

            return View(objUser); //we didn't do the whole viewModel thingie, in case that comes back to bite us in the a**e
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(ApplicationUser model, Patient patient)
        {
            model.UserName = model.IdNumber;
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(u => u.Id == model.Id).FirstOrDefault();
                var obj = _context.tblPatient.Where(u => u.Id == patient.Id).FirstOrDefault();

                if(user == null)
                {
                    return NotFound();
                }

                if(obj == null)
                {
                    return NotFound();
                }

                user.IdNumber = model.IdNumber;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Password = model.Password;
                user.Archived = model.Archived;

                patient.IdNumber = model.IdNumber;
                patient.FirstName = model.FirstName;
                patient.LastName = model.LastName;
                patient.Email = model.Email;
                patient.PhoneNumber = model.PhoneNumber;
                patient.Archived = model.Archived;

                _context.Users.Update(user);
                _context.tblPatient.Update(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UserDetails([FromRoute] string Id)
        {
            var objUser = _context.Users.Where(u => u.Id == Id && (u.Archived == true || u.Archived == false)).FirstOrDefault();

            if (objUser == null)
                return NotFound();

            return View(objUser); //we didn't do the whole viewModel thingie, in case that comes back to bite us in the a**e
        }

        public IActionResult DeleteUser([FromRoute] string Id)
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
    } 
}
