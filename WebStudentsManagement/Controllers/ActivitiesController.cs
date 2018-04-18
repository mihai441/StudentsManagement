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
using WebStudentsManagement.Models;
using WebStudentsManagement.Models.ManageViewModels;
using WebStudentsManagement.Services;

namespace WebStudentsManagement.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ActivitiesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;

        private bool student = false;

        private const string AuthenicatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

        public ActivitiesController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IEmailSender emailSender,
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _urlEncoder = urlEncoder;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (student)
            {
                List<string> activitiesName = new List<string>
                {
                    "Activity 1",
                    "Activity 2",
                    "Activity 3"
                };

                List<int> activitiesId = new List<int>
                {
                    1,
                    2,
                    3
                };

                List<string> activitiesType = new List<string>
                {
                    "C",
                    "S",
                    "L"
                };

                List<string> activitiesDescription = new List<string>
                {
                    "Class 101",
                    "Class 102",
                    "Class 103"
                };

                var model = new Activities
                {
                    ActivitiesName = activitiesName,
                    IdActivities = activitiesId,
                    ActivitiesType = activitiesType,
                    ActivitiesDescription = activitiesDescription
                };

                return View("StudentActivities", model);
            }
            else
            {
                List<string> activitiesName = new List<string>
                {
                    "Activity 4",
                    "Activity 5",
                    "Activity 6"
                };

                List<int> activitiesId = new List<int>
                {
                    4,
                    5,
                    6
                };

                List<string> activitiesType = new List<string>
                {
                    "S",
                    "L",
                    "C"
                };

                List<string> activitiesDescription = new List<string>
                {
                    "Class 104",
                    "Class 105",
                    "Class 106"
                };

                var model = new Activities
                {
                    ActivitiesName = activitiesName,
                    IdActivities = activitiesId,
                    ActivitiesType = activitiesType,
                    ActivitiesDescription = activitiesDescription
                };

                return View("TeacherActivities", model);
            }
        }

        // GET: Activities/Activity/{activityId}
        [HttpGet]
        [Route("{activityId}")]
        public async Task<IActionResult> Activity(int? activityId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
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

        // GET: Activities/Activity/{activityId}/Student/{studentId}/{method}
        // method = "add", "details", "edit"
        [HttpGet]
        [Route("{activityId}/Student/{studentId}/{method}")]
        public async Task<IActionResult> Activity(int? activityId, int? studentId, string method)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (activityId == null || studentId == null || method == null)
            {
                return NotFound();
            }

            int idActivity = activityId ?? default(int);
            int idStudent = studentId ?? default(int);

            /*
             * Dummy data for activity test
             * */

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
                IdActivity = idActivity,
                ActivityName = activityName,
                StudentName = studentName,
                StudentId = idStudent,
                Date = dateTime,
                Grade = grade,
                Attendance = attendance
            };

            if (method == "Details")
            {
                return View("TeacherActivityOfAStudent", model);
            }
            else if (method == "Add")
            {
                return View("TeacherAddActivityOfAStudent", model);
            }
            else if (method == "Edit")
            {
                return View("TeacherEditActivityOfAStudent", model);
            }
            else
            {
                return NotFound();
            }
        }
    }
}