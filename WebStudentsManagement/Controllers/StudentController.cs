using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using WebStudentsManagement.Models.ManageViewModels;

namespace WebStudentsManagement.Controllers
{
    [Route("[controller]/[action]")]
    public class StudentController : Controller
    {
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;
        private readonly IBusinessLayer _businessLogic;
        private readonly IAuthentication _auth;
        private readonly IStudentServices _studentServices;

        private const string AuthenicatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

        public StudentController(
          IBusinessLayer businessLayer,
          ILogger<StudentController> logger,
          UrlEncoder urlEncoder,
          IAuthentication auth)
        {
            _businessLogic = businessLayer;
            _auth = auth;
            _studentServices = _businessLogic.GetStudentOperationService();
            _logger = logger;
            _urlEncoder = urlEncoder;
        }


        public string StatusMessage { get; set; }


        public async Task<IActionResult> Index()
        {
            return View("Activities" , new Activities { ActivitiesList = _studentServices.GetUserActivities(await _auth.GetUserNameAsync(User)) });
        }

        // GET: Activities/Activity/{activityId}
        [HttpGet]
        [Route("{activityId}", Name = "ActivityDetails")]
        public async Task<IActionResult> Activity(int? activityId)
        {
            IActionResult retView = View();
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }
            if ( await _auth.IsTeacher(User))
            {
                return RedirectToAction(nameof(TeacherController.Index), "Home");
            }

            int idActivity = activityId ?? default(int);

            {
                Activity currentActivity = _studentServices.GetActivity(idActivity);

                if (currentActivity != null)
                {
                    List<ActivityDate> studentActivitiesDates = _studentServices.GetActivityDates(idActivity, await _auth.GetUserIdAsync(User)).ToList();

                    var model = new StudentActivityInfo
                    {
                        ActivityDates = studentActivitiesDates,
                        ActivityName = currentActivity.Name
                    };

                    retView = View("StudentActivity", model);
                }
            }

            return retView;
        }

    


    }
}