using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
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
    
    [Route("[controller]/[action]")]
    public class ActivitiesController : Controller
    {
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;
        private readonly IBusinessLayer _businessLogic;
        private readonly IAuthentication _auth;
        private readonly IStudentServices _studentServices;

        private const string AuthenicatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

        public ActivitiesController(
          IBusinessLayer businessLayer,
          ILogger<ActivitiesController> logger,
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _auth.IsUserValid(User);
            if (!result)
            {
                throw new ApplicationException($"Unable to load user");
            }

            List<Activity> activities = (List<Activity>)_studentServices.PersistenceContext.ActivityRepository.ListAll();


            var model = new Activities
            {
                ActivitiesList = activities
            };

            if (await _auth.IsTeacher(User))
            {
                return View("TeacherActivities", model);
            }
            else
            {
                return View("StudentActivities", model);
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

            if (activityId == null || await _auth.IsTeacher(User) != true)
            {
                return NotFound();
            }

            int idActivity = activityId ?? default(int);


            if (await _auth.IsTeacher(User))
            {

                List<Student> students = _studentServices.PersistenceContext.StudentsRepository.ListAllFromActivity(idActivity).ToList();


                var model = new AllStudentsOnActivity
                {
                    Students = students
                };

                return View("TeacherActivity", model);
            }
            else
            {
                List<ActivityDate> studentActivitiesDates = _studentServices.PersistenceContext.ActivityDetailsRepository.GetActivityDates(idActivity, await _auth.GetUserIdAsync(User)).ToList();

                var model = new StudentActivityInfo
                {
                   ActivityDates = studentActivitiesDates
                };

                return View("StudentActivity", model);
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

            //if (CheckExistingActivity(idActivity) == null || CheckExistingStudent(idStudent) == null)
            //{
            //    return NotFound();
            //}

            if (await _auth.IsTeacher(User))
            {
                List<ActivityDate> studentActivitiesDates = _studentServices.PersistenceContext.ActivityDetailsRepository.GetActivityDates(idActivity, idStudent).ToList();


                var model = new StudentActivityInfo
                {
                    ActivityDates = studentActivitiesDates
                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
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

            //if (CheckExistingActivity(idActivity) == null || CheckExistingStudent(idStudent) == null)
            //{
            //    return NotFound();
            //}

            if (await _auth.IsTeacher(User))
            {
                //string activityName = GetActivityName(idActivity);
                //string studentName = GetStudentName(idStudent);

                var model = new SingleStudentActivityInfo
                {
                    IdActivity = idActivity,
                    //ActivityName = activityName,
                    //StudentName = studentName,
                    StudentId = idStudent
                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
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

            //if (CheckExistingActivity(idActivity) == null || CheckExistingStudent(idStudent) == null
            //    || CheckExistingActivityColumnId(idFinal) == null)
            //{
            //    return NotFound();
            //}

            //double grade = GetActivityGradeById(idFinal);
            //bool attendance = GetActivityAttendanceById(idFinal);
            //DateTime dateTime = GetActivityDateById(idFinal);
            //string activityName = GetActivityName(idActivity);
            //string studentName = GetStudentName(idStudent);

            var model = new SingleStudentActivityInfo
            {
                Id = idFinal,
                IdActivity = idActivity,
                //ActivityName = activityName,
                //StudentName = studentName,
                StudentId = idStudent,
                //Date = dateTime,
                //Grade = grade,
                //Attendance = attendance
            };

            return View(model);
        }

        // POST: Activities/TeacherActivityEdit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TeacherActivityEdit(int? id, [Bind("IdActivity, ,StudentId, Date, Grade, Attendance")] SingleStudentActivityInfo studentActivityInfoRow)
        {
            //if (CheckExistingActivityColumnId(id) == false)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                //try
                //{
                //    _context.Update(student);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!StudentExists(student.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }
    }
}