using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                int id = idActivity;
                var model = new AllStudentsOnActivity
                {
                    Students = students,   
                    ActivityName = name,
                    ActivityId = id
                };

                return View("TeacherActivity", model);
            }
        }

        // GET: Activities/TeacherActivityDetails/{activityId}/Student/{studentId}
        [HttpGet]
        [Route("{activityId}/Student/{studentId}", Name = "StudentDetails")]
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
        public async Task<IActionResult> TeacherActivityAdd(int? activityId, int? studentId)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (activityId == null 
                || !await _auth.IsTeacher(User)
                || studentId == null)
            {
                return NotFound();
            }

            int idActivityDate = activityId ?? default(int);
            int idStudent = studentId ?? default(int);

            Student student = _teacherServices.GetStudent(idStudent);
            Activity activity = _teacherServices.GetActivity(idActivityDate);

            var activityDate = new ActivityDate()
            {
                ActivityId = activity.Id,
                StudentId = student.Id,
                Date = DateTime.Now,
                Grade = 0,
                Attendance = false
            };

            var model = new SingleStudentActivityInfo
            {
                ActivityDate = activityDate,
                Student = student,
                Activity = activity
            };

            return View(model);
        }

        [HttpGet]
        [Route("{activityId}")]
        public async Task<IActionResult> AddStudentToActivity(int? activityId)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (activityId == null
                || !await _auth.IsTeacher(User))
            {
                return NotFound();
            }

            int idActivityDate = activityId ?? default(int);

            Activity activity = _teacherServices.GetActivity(idActivityDate);


            //TODO: filter the students which already participate to activity
            var studentList = _teacherServices.GetAllStudents();

            var model = new AddStudentToActivity
            {
                Activity = activity,
                StudentList = studentList
            };

            return View(model);
        }

        // POST: Activities/TeacherActivityAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateActivity([Bind("ActivityId,StudentId,Date,Grade,Attendance")] ActivityDate activityDate)
        {
            if (ModelState.IsValid)
            {
                // trebuie modificat si-n model dupa exemplul cu SingleRowActivityInfo
                _teacherServices.AddActivityDate(activityDate);
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: Activities/TeacherActivityEdit/{activityId}/Student/{studentId}/Id/{Id}
        [HttpGet]
        [Route("{activityId}/Student/{studentId}/Id/{Id}")]
        public async Task<IActionResult> TeacherActivityEdit(int? activityId, int? studentId, int? Id)
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            if (activityId == null || !await _auth.IsTeacher(User))
            {
                return NotFound();
            }

            int idActivityDate = activityId ?? default(int);
            int idStudent = studentId ?? default(int);
            int IdRow = Id ?? default(int);

            //testing output with list
            var activityDate = _teacherServices.GetActivityDate(IdRow);

            Student student = _teacherServices.GetStudent(idStudent);
            Activity activity = _teacherServices.GetActivity(idActivityDate);

            var model = new SingleStudentActivityInfo
            {
                ActivityDate = activityDate
            };

            return View(model);
        }

        // POST: Activities/TeacherActivityEdit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TeacherActivityModify(int? id, [Bind("Id, ActivityId, StudentId, Date, Grade, Attendance")] ActivityDate activityDate)
        {

            if (id == null || !await _auth.IsTeacher(User))
            {
                return NotFound();
            }

            int activityId = id ?? default(int);

            if (ModelState.IsValid)
            {

                _teacherServices.UpdateActivityDate(activityDate);
                

                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{activityId}")]
        public async Task<IActionResult> AddStudentToActivity(int? activityId, [Bind("inputList")] List<string> studentNames)
        {
            if (activityId == null || !await _auth.IsTeacher(User))
            {
                return NotFound();
            }

            int actId = activityId ?? default(int);

            if (ModelState.IsValid)
            {

                _teacherServices.AddStudentsToActivity(studentNames,actId);


                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }
    }
}