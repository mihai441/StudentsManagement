using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using WebStudentsManagement.Models;
using WebStudentsManagement.Models.ManageViewModels;
using WebStudentsManagement.Services;

namespace WebStudentsManagement.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ActivitiesController : Controller
    {


        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;
        private readonly IBusinessLayer _businessLogic;
        private readonly IAuthentication _auth;
        private readonly IStudentServices _studentServices;

        private bool student = false;

        private const string AuthenicatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

        public ActivitiesController(
          IBusinessLayer businessLayer,
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder)
        {
            _businessLogic = businessLayer;
            _auth = _businessLogic.GetAuthenticationService();
            _studentServices = _businessLogic.GetStudentOperationService();
            _logger = logger;
            _urlEncoder = urlEncoder;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (_auth.IsTeacher(User))
            {
                List<Activity> activities = (List<Activity>)_studentServices.PersistenceContext.ActivityRepository.GetActivities();

                var model = new Activities();
                
                //foreach(var activity in activities)
                //{
                //    model.ActivityName = activity.Name;
                //    model.IdActivity = activity.IdAct;
                //}

                return View("StudentActivities", model);
            }
            else
            {
                List<Activity> activities = (List<Activity>)_studentServices.PersistenceContext.ActivityRepository.GetActivities();

                List<int> idActivities = new List<int>();
                List<string> activitiesName = new List<string>();
                List<string> activitiesDescription = new List<string>();
                List<string> activitiesType = new List<string>();

                foreach (var activity in activities)
                {
                    idActivities.Add(activity.IdAct);
                    activitiesName.Add(activity.Name);
                    activitiesDescription.Add(activity.Description);
                    string type = GetActivityType(activity.IdAct);
                    activitiesType.Add(type);
                }

                var model = new Activities
                {
                    IdActivities = idActivities,
                    ActivitiesName = activitiesName,
                    ActivitiesType = activitiesType,
                    ActivitiesDescription = activitiesDescription
                };

                return View("TeacherActivities", model);
            }
        }

        // GET: Activities/Activity/{activityId}
        [HttpGet]
        [Route("{activityId}", Name = "ActivityDetails")]
        public async Task<IActionResult> Activity(int? activityId)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (activityId == null)
            {
                return NotFound();
            }

            int idActivity = activityId ?? default(int);

            /*
             * Check if student exists
            if (ExistingActivity(idActivity) == null)
            {
                return NotFound();
            }
            */

            /*
             * Dummy data for activity test
             * */

            if (student)
            {
                List<DateTime> dateTime = new List<DateTime>
                {
                    new DateTime(2018, 5, 4),
                    new DateTime(2018, 5, 5),
                    new DateTime(2018, 5, 6),
                    new DateTime(2018, 5, 7)
                };

                List<double> grade = new List<double>
                {
                    9,
                    8.5,
                    0,
                    7.25
                };

                List<bool> attendance = new List<bool>
                {
                    true,
                    true,
                    false,
                    true
                };

                string activityName = "E-learning";

                var model = new StudentActivityInfo
                {
                    IdActivity = idActivity,
                    ActivityName = activityName,
                    Date = dateTime,
                    Grade = grade,
                    Attendance = attendance
                };

                return View("StudentActivity", model);
            }
            else
            {
                List<int> studentId = new List<int>
                {
                    1,
                    2,
                    3
                };

                List<string> name = new List<string>
                {
                    "Ionel",
                    "Georgel",
                    "Mihai"
                };

                string activityName = "E-learning";

                var model = new AllStudentsOnActivity
                {
                    Id = studentId,
                    Name = name,
                    ActivityName = activityName,
                    ActivityId = idActivity
                };

                return View("TeacherActivity", model);
            }
        }

        // GET: Activities/TeacherActivityDetails/{activityId}/Student/{studentId}
        [HttpGet]
        [Route("{activityId}/Student/{studentId}")]
        public async Task<IActionResult> TeacherActivityDetails(int? activityId, int? studentId)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (activityId == null || studentId == null)
            {
                return NotFound();
            }

            int idActivity = activityId ?? default(int);
            int idStudent = studentId ?? default(int);

            /*
             * Dummy data for activity test
             * */

            List<int> id = new List<int>
            {
                5,
                6,
                7,
                8
            };

            List<DateTime> dateTime = new List<DateTime>
            {
                new DateTime(2018, 5, 4),
                new DateTime(2018, 5, 5),
                new DateTime(2018, 5, 6),
                new DateTime(2018, 5, 7)
            };

            List<double> grade = new List<double>
            {
                9,
                8.5,
                0,
                7.25
            };

            List<bool> attendance = new List<bool>
            {
                true,
                true,
                false,
                true
            };

            string activityName = "E-learning";

            string studentName = "Mihai";

            var model = new StudentActivityInfo
            {
                Id = id,
                IdActivity = idActivity,
                ActivityName = activityName,
                StudentName = studentName,
                StudentId = idStudent,
                Date = dateTime,
                Grade = grade,
                Attendance = attendance
            };

            return View(model);
        }

        // GET: Activities/TeacherActivityAdd/{activityId}/Student/{studentId}
        [HttpGet]
        [Route("{activityId}/Student/{studentId}")]
        public async Task<IActionResult> TeacherActivityAdd(int? activityId, int? studentId)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (activityId == null || studentId == null)
            {
                return NotFound();
            }

            int idActivity = activityId ?? default(int);
            int idStudent = studentId ?? default(int);

            /*
             * Dummy data for activity test
             * */

            string studentName = "Mihai";

            string activityName = "E-learning";

            var model = new SingleStudentActivityInfo
            {
                IdActivity = idActivity,
                ActivityName = activityName,
                StudentName = studentName,
                StudentId = idStudent
            };

            return View(model);
        }

        // POST: Activities/TeacherActivityAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TeacherActivityAdd([Bind("IdActivity,StudentId,Date,Grade,Attendance")] SingleStudentActivityInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                // AICI TREBUIE MODIFICAT
                //_context.Add(studentInfo);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(TeacherActivityDetails(studentInfo.IdActivity, studentInfo.StudentId));
                // AICI TREBUIE MODIFICAT - CATA
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: Activities/TeacherActivityEdit/{activityId}/Student/{studentId}/Id/{Id}
        [HttpGet]
        [Route("{activityId}/Student/{studentId}/Id/{Id}")]
        public async Task<IActionResult> TeacherActivityEdit(int? activityId, int? studentId, int? id)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (activityId == null || studentId == null || id == null)
            {
                return NotFound();
            }

            int idActivity = activityId ?? default(int);
            int idStudent = studentId ?? default(int);
            int idFinal = id ?? default(int);

            /*
             * Dummy data for activity test
             * */

            double grade = 7.25;

            bool attendance = true;

            DateTime dateTime = new DateTime(2018, 5, 4);

            string activityName = "E-learning";

            string studentName = "Mihai";

            var model = new SingleStudentActivityInfo
            {
                Id = idFinal,
                IdActivity = idActivity,
                ActivityName = activityName,
                StudentName = studentName,
                StudentId = idStudent,
                Date = dateTime,
                Grade = grade,
                Attendance = attendance
            };

            return View(model);
        }
    }
}