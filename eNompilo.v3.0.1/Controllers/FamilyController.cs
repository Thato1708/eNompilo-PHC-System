using eNompilo.v3._0._1.Models;
using eNompilo.v3._0._1.Data;
using eNompilo.v3._0._1.Areas.Identity.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eNompilo.v3._0._1.Models.Family_Planning;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Security.Policy;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;
using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using eNompilo.v3._0._1.Models.Family_Planning.ViewModel;

namespace eNompilo.v3._0._1.Controllers
{
    
    public class FamilyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public FamilyController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {

                
                if (User.IsInRole(RoleConstants.Patient))
                {
                    var pts = _context.tblPatient.Where(p => p.UserId == _userManager.GetUserId(User)).FirstOrDefault();
                    if (pts != null)
                    {
                        var patientId = pts.Id;
                        IEnumerable<FamilyPlanningAppointment> objList = _context.tblFamilyPlanningAppointment.Where(va => va.Archived == false && va.PatientId == patientId).ToList();
                        return View(objList);
                    }
                    
                }
                else if (User.IsInRole(RoleConstants.Admin))
                {
                    IEnumerable<FamilyPlanningAppointment> objList = _context.tblFamilyPlanningAppointment;
                    return View(objList);
                }
            }
            return NotFound();
        }
        public IActionResult IndexList()
        {
            var pts= _context.tblPractitioner.Where(p => p.UserId == _userManager.GetUserId(User)).FirstOrDefault();
            if (pts != null)
            {
                var ptsid = pts.UserId;
                IEnumerable<FamilyPlanningAppointment> objList = _context.tblFamilyPlanningAppointment.Where(va => va.Archived == false && va.ResponsiblePractitionerId == ptsid).ToList();
                return View(objList);
            }
            
                
            return NotFound();
        }


        //public IActionResult Index()
        //{
        //    if (_signInManager.IsSignedIn(User))
        //    {
        //        if (User.IsInRole(RoleConstants.Patient))
        //        {
        //            IEnumerable<FamilyPlanningAppointment> objList = _context.tblFamilyPlanningAppointment.Where(va => va.Archived == false).ToList();
        //            return View(objList);
        //        }
        //        else if (User.IsInRole(RoleConstants.Admin))
        //        {
        //            IEnumerable<FamilyPlanningAppointment> objList = _context.tblFamilyPlanningAppointment;
        //            return View(objList);
        //        }
        //    }
        //    return NotFound();
        //}

        public IActionResult Detail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.FindByIdAsync(id).Result; // Use UserManager to retrieve the user

            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName =user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };

            return View(userViewModel);
        }
        public IActionResult PatientDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.FindByIdAsync(id).Result; 
            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,

            };

            return View(userViewModel);
        }
        public IActionResult Book()
        {
            var bookedAppointments = _context.tblFamilyPlanningAppointment
                .Select(a => new { a.PreferredDate, a.PreferredTime })
                .ToList();

            ViewBag.BookedAppointments = bookedAppointments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(FamilyPlanningAppointment model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var randomPractitioner = _context.Users
                    .Where(p => p.UserRole == UserRole.Practitioner)
                    .ToList();
                var random = new Random();
                var rp = randomPractitioner[random.Next(randomPractitioner.Count)];
                if (randomPractitioner != null)
                {
                    model.IsCollected = false;
                    model.ResponsiblePractitionerId = rp.Id;
                    _context.tblFamilyPlanningAppointment.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                {
                    return View("NoPA");
                }

            }
            return View(model);
        }

        public IActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _context.tblFamilyPlanningAppointment.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(FamilyPlanningAppointment model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.tblFamilyPlanningAppointment.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detailz(int? Id)
        {
            var obj = _context.tblFamilyPlanningAppointment.Find(Id);
            if (obj == null)
                return View("PageNotFound", "Home");
            return View(obj);
        }

        public IActionResult Details(int? Id)
        {
            var obj = _context.tblFamilyPlanningAppointment.Find(Id);
            if (obj == null)
                return View("PageNotFound", "Home");
            return View(obj);
        }

        public IActionResult Cancel( int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            var obj = _context.tblFamilyPlanningAppointment.Where(va => va.Id == Id).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }

            var model = new ArchiveItemViewModel
            {
                Id = obj.Id,
                FPAppointmentId = obj.Id,
                Archived = obj.Archived
            };

            return View(model);
        }

        [HttpPost,ActionName ("Cancel")]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(ArchiveItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = _context.tblFamilyPlanningAppointment.Where(va => va.Id == model.Id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }

            obj.Archived = model.Archived;


            _context.tblFamilyPlanningAppointment.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    
        public static List<RecommendedContraceptive>? selectedConditions = null;
        public IActionResult RecommendContraceptive()
        {
            selectedConditions = new();
            return View();
        }
        public IActionResult RecommendResult()
        {
            List<string> oral = new()
            {
                "History of blood clots or thromboembolic disorders.",
                "Cardiovascular conditions.",
                "Liver disease or impaired liver function.",
                "Estrogen-sensitive cancers (e.g., certain types of breast cancer).",
                "Migraine with aura.",
                "Allergies to contraceptive components, such as estrogen or progestin."
            };
            List<string> Mirena = new()
            {
                "Active pelvic inflammatory disease (PID) or current pelvic infection.",
                "Unexplained vaginal bleeding.",
                "Certain uterine abnormalities.",
                "Pregnancy (IUDs are not recommended during pregnancy)."
            };
            List<string> Copper = new()
            {
                "Allergy to copper (very rare).",
                "Active pelvic inflammatory disease (PID) or current pelvic infection.",
                "Unexplained vaginal bleeding.",
                "Certain uterine abnormalities.",
                "Pregnancy (IUDs are not recommended during pregnancy)."
            };
            List<string> Injection = new()
            {
                "Allergy to the components of the injection.",
                "History of blood clots or thromboembolic disorders.",
                "Certain liver conditions.",
                "Unexplained vaginal bleeding.",
                "Estrogen-sensitive cancers.",
                "Current or past liver tumors."
            };
            List<string> Patch = new()
            {
                "History of blood clots or thromboembolic disorders.",
                "Certain liver conditions.",
                "Uncontrolled high blood pressure.",
                "History of certain types of cancer.",
                "Migraine with aura.",
                "Certain heart or vascular conditions.",
                "Smoking while over the age of 35.",
                "Known or suspected pregnancy."
            };
            List<string> Implant = new()
            {
                "Allergy to the components of the implant.",
                "History of blood clots or thromboembolic disorders.",
                "Certain liver conditions.",
                "Unexplained vaginal bleeding.",
                "Estrogen-sensitive cancers.",
                "Current or past liver tumors.",
                "Known or suspected pregnancy."
            };
            List<string> ring = new()
            {
                "Allergy to the components of the ring.",
                "History of blood clots or thromboembolic disorders.",
                "Certain liver conditions.",
                "Uncontrolled high blood pressure.",
                "Estrogen-sensitive cancers.",
                "Current or past liver tumors.",
                "Known or suspected pregnancy.",
                "Smoking while over the age of 35.",
                "Migraine with aura.",

            };
            if (selectedConditions == null)
            {
                TempData["Error"] = "Please select a contraceptive";
                return RedirectToAction(nameof(RecommendContraceptive));
            }
            List<string> Recommend = new()
            {
                "Oral",
                "Mirena",
                "Copper",
                "Injections",
                "Implant",
                "Patches",
                "Contraceptive Ring"
            };
            foreach (var s in selectedConditions)
            {
                if (oral.Contains(s.Name))
                {
                    Recommend.Remove("Oral");
                }
                if (Mirena.Contains(s.Name))
                {
                    Recommend.Remove("Mirena");
                }
                if (Copper.Contains(s.Name))
                {
                    Recommend.Remove("Copper");
                }
                if (Injection.Contains(s.Name))
                {
                    Recommend.Remove("Injections");
                }
                if (Implant.Contains(s.Name))
                {
                    Recommend.Remove("Implant");
                }
                if (ring.Contains(s.Name))
                {
                    Recommend.Remove("Contraceptive Ring");
                }
                if (Patch.Contains(s.Name))
                {
                    Recommend.Remove("Patches");
                }
            }
            List<RecommendedContraceptive> recommend = new();
            foreach (var item in Recommend)
            {
                RecommendedContraceptive i = new()
                {
                    Name = item
                };
                recommend.Add(i);
            }
            selectedConditions.Clear();
            selectedConditions = null;

            return View(recommend);
        }
        [HttpPost]
        public IActionResult RecommendContraceptive(RecommendedContraceptive condition)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid Selection. Please select a condition";
                return View();
            }
            selectedConditions ??= new();
            
            selectedConditions.Add(condition);
            ViewBag.Condition = selectedConditions;
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }
        public async Task<IActionResult> DeleteContraceptive(int? ContraceptiveId)
        {
            if (ContraceptiveId == null || ContraceptiveId > 0)
            {
                return NotFound();
            }
            var obj = await _context.Contraceptives.FindAsync(ContraceptiveId);
            if (obj == null)
            {
                return NotFound();
            }
            obj.IsActive = 0;
            _context.Contraceptives.Update(obj);
            await _context.SaveChangesAsync();
            TempData["Result"] = $"{obj.ContraceptiveName} has been successfully updated.";
            return View("Result");
        }
        [HttpPost]
        public async Task<IActionResult> ManageContraceptive(Contraceptive contraceptive)
        {
            if (!ModelState.IsValid)
            {
                return View(contraceptive);
            }
            _context.Contraceptives.Update(contraceptive);
            await _context.SaveChangesAsync();

            TempData["Result"] = $"{contraceptive.ContraceptiveName} has been successfully updated.";
            return View("Result");
        }
        public async Task<IActionResult> ManageContraceptive(int? ContraceptiveId)
        {
            if (ContraceptiveId == null || ContraceptiveId > 0)
            {
                return NotFound();
            }
            var contraceptive = await _context.Contraceptives.FindAsync(ContraceptiveId);
            if (contraceptive == null)
            {
                return NotFound();
            }
            return View(contraceptive);
        } 
        public IActionResult AddContraceptive()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddContraceptive(Contraceptive contraceptive)
        {
            if (!ModelState.IsValid)
            {
                return View(contraceptive);
            }
            await _context.Contraceptives.AddAsync(contraceptive);
            await _context.SaveChangesAsync();
            TempData["Result"] = $"{contraceptive.ContraceptiveName} has been successfully added.";
            return View("Result");
        }
        public IActionResult PatientSymptom()
        {
            SelectedConditions.Clear();
            var conditions = _context.Conditions;
            var obj1 = from x in conditions
                       select new
                       {
                           Name = x.ConditionDescription,
                           Id = x.ConditionId
                       };
            ViewBag.Select = new SelectList(obj1, "Name", "Name");
            return View();
        }
        private static List<SelectedCondition> SelectedConditions = new();
        [HttpPost]
        public IActionResult PatientSymptom(SelectedCondition selected)
        {
            if (!ModelState.IsValid)
            {
                return View(selected);
            }
            SelectedConditions.Add(selected);
            var conditions = _context.Conditions;
            var obj1 = from x in conditions
                       select new
                       {
                           Name = x.ConditionDescription,
                           Id = x.ConditionId
                       };
            ViewBag.Select = new SelectList(obj1, "Name", "Name");
            ViewBag.Conditions = SelectedConditions;
            return View();
        }
        public async Task<IActionResult> AddPatientSymptom()
        {
            if (SelectedConditions.Count > 0)
            {
                await _context.SelectedConditions.AddRangeAsync(SelectedConditions);
                await _context.SaveChangesAsync();
                SelectedConditions.Clear();
                return View(nameof(Index));

            }

            return View(nameof(PatientSymptom));
        }
        
        public IActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SelectDate(SelectDates selectDates)
        {
            if (!ModelState.IsValid)
            {
                return View(selectDates);
            }
            _context.SelectDates.Add(selectDates);
            _context.SaveChanges();
            TempData["Result"] = "Appointment has been booked successfully";
            return View("Result");
        }
        [HttpPost]
        public IActionResult Booking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return View(booking);
            }
            if (booking.Reason == "Contraceptive")
            {
                ContraceptiveBooking contraceptiveb = new()
                {
                    UserID = booking.UserID,
                    Reason = booking.Reason,
                };
                var obj = _context.Contraceptives.Where(x => x.IsActive == 1);
                var obj1 = from x in obj
                           select new
                           {
                               Name = x.ContraceptiveName + " (" + x.ContraceptiveDuration + " days)",
                               Id = x.ContraceptiveId
                           };
                ViewBag.Contraceptive = new SelectList(obj1, "Id", "Name");
                return View(nameof(SelectContraceptive),contraceptiveb);
            }
            else
            {
                SelectDates select = new()
                {
                    UserID = booking.UserID,
                    Reason = booking.Reason,
                };
                return View(nameof(SelectDate), select);
            }
        }
        [HttpPost]
        public IActionResult SelectContraceptive(ContraceptiveBooking booking)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Booking), booking);
            }
            _context.ContraceptiveBookings.Add(booking);
            _context.SaveChanges();
            TempData["Result"] = "Appointment has been booked successfully";
            return View(nameof(SelectContraceptive));
        }


        // GET: FamilyPlanningAppointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyPlanningAppointment = await _context.tblFamilyPlanningAppointment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familyPlanningAppointment == null)
            {
                return NotFound();
            }

            return View(familyPlanningAppointment);
        }

        // POST: FamilyPlanningAppointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familyPlanningAppointment = await _context.tblFamilyPlanningAppointment.FindAsync(id);
            if (familyPlanningAppointment == null)
            {
                return NotFound();
            }

            _context.tblFamilyPlanningAppointment.Remove(familyPlanningAppointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: FamilyPlanningAppointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyPlanningAppointment = await _context.tblFamilyPlanningAppointment.FindAsync(id);
            if (familyPlanningAppointment == null)
            {
                return NotFound();
            }

            return View(familyPlanningAppointment);
        }

        // POST: FamilyPlanningAppointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookingReasons,PreferredDate,PreferredTime,PatientId,PatientFileId,ResponsiblePractitionerId,Archived")] FamilyPlanningAppointment familyPlanningAppointment)
        {
            if (id != familyPlanningAppointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familyPlanningAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamilyPlanningAppointmentExists(familyPlanningAppointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(familyPlanningAppointment);
        }

        private bool FamilyPlanningAppointmentExists(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public IActionResult Collect(int id)
        {
            // Retrieve the item by ID from your data source (e.g., a database)
            var item = _context.tblFamilyPlanningAppointment.Find(id);

            if (item != null)
            {
                // Set IsCollected to true
                item.IsCollected = true;

                // Update the item in the data source
                _context.tblFamilyPlanningAppointment.Update(item);
                _context.SaveChanges();
            }

            // Redirect to the view that displays the updated item list
            return RedirectToAction("IndexList");
        }

        public async Task<IActionResult> PatientRecords()
        {
            var pts = _context.tblPatient.Where(p => p.UserId == _userManager.GetUserId(User)).FirstOrDefault();
            if (pts != null) 
            {
                var patientId = pts.Id;
                // Count booking records
                int bookingCount = await _context.tblFamilyPlanningAppointment.Where(va =>  va.PatientId == patientId).CountAsync();

                // Count contraceptive type records
                int contraceptiveTypeCount = await _context.tblFamilyPlanningAppointment.Where(va => va.IsCollected == false && va.PatientId == patientId).CountAsync();

                // Count status collection records
                int collectionStatusCount = await _context.tblFamilyPlanningAppointment.Where(va => va.Archived == false && va.PatientId == patientId).CountAsync();

                // Count contraceptive discontinuation records
                int discontinuationCount = await _context.tblFamilyPlanningAppointment.Where(va => va.Archived == false && va.PatientId == patientId).CountAsync();

                // Count weekly appointment records
                int weeklyAppointmentCount = await _context.tblFamilyPlanningAppointment.Where(va => va.PatientId == patientId).CountAsync();

                var loginpatient = _context.Users.Where(p => p.Id == _userManager.GetUserId(User)).FirstOrDefault();

                // Pass these counts to the view using a ViewModel or ViewBag
                ViewBag.BookingCount = bookingCount;
                ViewBag.ContraceptiveTypeCount = contraceptiveTypeCount;
                ViewBag.CollectionStatusCount = collectionStatusCount;
                ViewBag.DiscontinuationCount = discontinuationCount;
                ViewBag.WeeklyAppointmentCount = weeklyAppointmentCount;
                ViewBag.LoginpatientF = loginpatient.FullName;
                ViewBag.LoginpatientE = loginpatient.Email;
                ViewBag.LoginpatientI = loginpatient.IdNumber;
                ViewBag.LoginpatientP = loginpatient.PhoneNumber;
                return View();
            }
            else { return View(); }
        }
        // GET: FamilyPRecord/Details/5
        public ActionResult RecordDetails(int? id)
        {
            if (id == null)
            {
                return View("FPRecord");
            }

            FamilyPRecord familyPRecord = _context.FamilyPRecords.Find(id);

            if (familyPRecord != null)
            {
                return View(familyPRecord);
            }
            else 
            {
                return View("FPRecord");
            }
            
        }
        public ActionResult CreateRecord()
        {
            var availableAppointments = _context.tblFamilyPlanningAppointment
                                            .Where(appointment => !_context.FamilyPRecords.Any(record => record.FamilyPlanningAppointmentId == appointment.Id))
                                            .ToList();

            var viewModelList = new List<FamilyPlanningViewModel>();

            foreach (var appointment in availableAppointments)
            {
                var patient = _context.tblPatient.FirstOrDefault(p => p.Id == appointment.PatientId);

                if (patient != null)
                {
                    viewModelList.Add(new FamilyPlanningViewModel
                    {
                        FamilyPlanningAppointmentId = appointment.Id,
                        BookingReasons = appointment.BookingReasons,
                        Patient = patient
                    });
                }
            }

            // Populate the ViewBag with the ViewModel list.
            ViewBag.FamilyPlanningAppointments = viewModelList;

            return View();
        }

        //public ActionResult CreateRecord()
        //{
        //    var availableAppointments = _context.tblFamilyPlanningAppointment
        //        .Where(appointment => !_context.FamilyPRecords.Any(record => record.FamilyPlanningAppointmentId == appointment.Id))
        //        .ToList();

        //    var viewModelList = new List<FamilyPlanningViewModel>();

        //    foreach (var appointment in availableAppointments)
        //    {
        //        var patient = _context.tblPatient.FirstOrDefault(p => p.Id == appointment.PatientId);

        //        if (patient != null)
        //        {
        //            viewModelList.Add(new FamilyPlanningViewModel
        //            {
        //                FamilyPlanningAppointmentId = appointment.Id,
        //                CombinedText = $"{appointment.BookingReasons} - {patient.FullName}"
        //            });
        //        }
        //    }

        //    // Populate the ViewBag with the ViewModel list.
        //    ViewBag.FamilyPlanningAppointments = new SelectList(viewModelList, "FamilyPlanningAppointmentId", "CombinedText");

        //    return View();
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRecord(FamilyPlanningViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var selectedAppointmentId = viewModel.FamilyPlanningAppointmentId;

                // Fetch the related appointment using the selected ID.
                var selectedAppointment = _context.tblFamilyPlanningAppointment.FirstOrDefault(appointment => appointment.Id == selectedAppointmentId);

                if (selectedAppointment != null)
                {
                    // Create a new FamilyPRecord and populate its properties.
                    var familyPRecord = new FamilyPRecord
                    {
                        FamilyPlanningAppointmentId = selectedAppointment.Id,
                        DoctorId = selectedAppointment.ResponsiblePractitionerId, // Assuming the doctor is the patient's user.
                        DateOfVisit = DateTime.Now,
                        IsDiscontinued = false, // You can set the default value here.
                        MedicalNotes = viewModel.MedicalNotes,
                        StartDate = viewModel.StartDate,
                        EndDate = viewModel.EndDate,
                        DosageAmount = viewModel.DosageAmount,
                        DosageDuration = viewModel.DosageDuration,
                    };

                    _context.FamilyPRecords.Add(familyPRecord);
                    _context.SaveChanges();

                    return RedirectToAction("FPRecord"); // Redirect to the appropriate action.
                }
            }

            // If the model is not valid or there's an error, return to the view.
            // You may want to add error handling here.
            return View(viewModel);
        }


        // Dispose of the DbContext when it's no longer needed.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
        public IActionResult RecordAppointmentDetails(int? Id)
        {
            var obj = _context.tblFamilyPlanningAppointment.Find(Id);
            if (obj == null)
                return View("PageNotFound", "Home");
            return View(obj);
        }

        // GET: FamilyPlanningMedicalRecords
        public IActionResult FPRecord()
        {
            var familyPlanningMedicalRecords = _context.FamilyPRecords.ToList();
            return View(familyPlanningMedicalRecords);
        }
        // GET: FamilyPlanningMedicalRecords
        public IActionResult PatientRecord()
        {
            var pts = _context.tblPatient.Where(p => p.UserId == _userManager.GetUserId(User)).FirstOrDefault();
            if (pts != null)
            {
                var patientId = pts.Id;
                var familyPlanningMedicalRecords = _context.FamilyPRecords.Where(v => v.FamilyPlanningAppointment.PatientId == patientId).ToList();
                return View(familyPlanningMedicalRecords);
            }
            else
            {
                return View();
            }
        }

        // GET: FamilyPRecord/Edit/5
        public ActionResult RecordEdited()
        {

            return View();
        }

        // POST: FamilyPRecord/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecordEdit(int? id)
        {
            if (id == null)
            {
                return View("FPRecord");
            }

           var familyPRecord = _context.FamilyPRecords.Find(id);
            if (familyPRecord != null)
            {
                familyPRecord.IsDiscontinued = true;
                _context.Entry(familyPRecord).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("RecordEdited"); // Redirect to the appropriate action.
            }

            // You may need to repopulate dropdown lists here, similar to the Create action.

            return View(familyPRecord);
        }

    }
}
