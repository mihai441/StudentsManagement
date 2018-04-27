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
    public class TeacherController : Controller
    {
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;
        private readonly IBusinessLayer _businessLogic;
        private readonly IAuthentication _auth;
        private readonly ITeacherServices _teacherServices;

        private const string AuthenicatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

        public TeacherController(
          IBusinessLayer businessLayer,
          ILogger<TeacherController> logger,
          UrlEncoder urlEncoder,
          IAuthentication auth)
        {
            _businessLogic = businessLayer;
            _auth = auth;
            _teacherServices = _businessLogic.GetTeacherOperationService();
            _logger = logger;
            _urlEncoder = urlEncoder;
        }


        public string StatusMessage { get; set; }


        public async Task<IActionResult> Index()
        {
            return View("TeacherActivities", new Activities { ActivitiesList = _teacherServices.GetTeacherActivities(await _auth.GetUserNameAsync(User)) });
        }

        // GET: Activities/Activity/{activityId}
        [HttpGet]
        [Route("{activityId}", Name = "Activities")]
        public async Task<IActionResult> Activity(int? activityId)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (!await _auth.IsTeacher(User))
            {
                return NotFound();
            }

            int idActivity = activityId ?? default(int);

            {
                List<Student> students = _teacherServices.GetActivityStudents(idActivity).ToList();
                var name = _teacherServices.GetActivity(idActivity).Name;
                int id = 1; // aici
                var model = new AllStudentsOnActivity
                {
                    Students = students,   
                    ActivityName = name,
                    ActivityId = id
                };

                return View("TeacherActivities", model);
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

            if (activityId == null || ! await _auth.IsTeacher(User) )
            {
                return NotFound();
            }

            int idActivity = activityId ?? default(int);
            int idStudent = studentId ?? default(int);


            if (await _auth.IsTeacher(User))
            {
                List<ActivityDate> studentActivitiesDates = _teacherServices.GetActivityDates(idActivity, idStudent).ToList();
                Student student = _teacherServices.GetStudent(idStudent);
                Activity activity = _teacherServices.GetActivity(idActivity);

                var model = new TeacherActivityInfo
                {
                    ActivityDates = studentActivitiesDates,
                    Student = student,
                    Activity = activity

                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Teacher/ActivityAdd/{activityId}/Student/{studentId}
        [HttpGet]
        [Route("{activityId}/Student/{studentId}")]
        public async Task<IActionResult> TeacherActivityAdd(int? activityDateId)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (activityDateId == null || !await _auth.IsTeacher(User))
            {
                return NotFound();
            }

            int idActivityDate = activityDateId ?? default(int);

            var activityDate = _teacherServices.GetActivityDate(idActivityDate);

            var model = new SingleStudentActivityInfo
            {
                ActivityDate = activityDate
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
                _teacherServices.AddActivityDate(studentInfo.Date, studentInfo.Grade, studentInfo.Attendance, studentInfo.IdActivity, studentInfo.StudentId);
                var result = _studentServices.PersistenceContext.Complete();
                return RedirectToAction(nameof(IndexAsync));
            }
            return View("Index");
        }

        // GET: Activities/TeacherActivityEdit/{activityId}/Student/{studentId}/Id/{Id}
        [HttpGet]
        [Route("{activityId}/Student/{studentId}/Id/{Id}")]
        public async Task<IActionResult> TeacherActivityEdit(int? activityDateId)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (activityDateId == null || !await _auth.IsTeacher(User))
            {
                return NotFound();
            }

            int idActivityDate = activityDateId ?? default(int);

            var activityDate = _studentServices.PersistenceContext.ActivityRepository.GetActivityDate(idActivityDate);


            var model = new SingleStudentActivityInfo
            {
                IdActivity = idActivityDate,
                StudentId = activityDate.StudentId,
                ActivityName = activityDate.Activity.Name,
                StudentName = activityDate.Student.Name,
                Attendance = activityDate.Attendance,
                Grade = activityDate.Grade,
                Date = activityDate.Date
            };

            return View(model);
        }

        // POST: Activities/TeacherActivityEdit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TeacherActivityEdit(int? id, [Bind("IdActivity, ,StudentId, Date, Grade, Attendance")] SingleStudentActivityInfo studentActivityInfoRow)
        {
           
            if (ModelState.IsValid)
            {
                var activityDate = _studentServices.PersistenceContext.ActivityRepository.GetActivityDate(studentActivityInfoRow.Id);

                //Edit part, maybe integrated in repository?

                activityDate.Id = studentActivityInfoRow.Id;
                activityDate.StudentId = studentActivityInfoRow.StudentId;
                activityDate.ActivityId = studentActivityInfoRow.IdActivity;
                activityDate.Date = studentActivityInfoRow.Date;
                activityDate.Grade = studentActivityInfoRow.Grade;
                activityDate.Attendance = studentActivityInfoRow.Attendance;

                _studentServices.PersistenceContext.Complete();

                return RedirectToAction(nameof(IndexAsync));
            }
            return View("Index");
        }
    }
}