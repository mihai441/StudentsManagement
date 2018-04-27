using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Core
{
    class TeacherServices : ITeacherServices
    {
        private IPersistenceContext _persistenceContext;


        public TeacherServices(IPersistenceContext persistenceContext)
        {
            PersistenceContext = persistenceContext;
        }

        public IPersistenceContext PersistenceContext { get => _persistenceContext; set => _persistenceContext = value; }

        public void AddActivityDate(DateTime date, double grade, bool attendance, int idActivity, int studentId)
        {
            PersistenceContext.ActivityRepository.AddActivityDate(date, grade, attendance, idActivity, studentId);
            PersistenceContext.Complete();
        }

        public Activity GetActivity(int idActivity)
        {
            return PersistenceContext.ActivityRepository.GetEntity(idActivity);
        }

        public ActivityDate GetActivityDate(int idActivityDate)
        {
            return PersistenceContext.ActivityRepository.GetActivityDate(idActivityDate);
        }

        public IEnumerable<ActivityDate> GetActivityDates(int idActivity, int studentId)
        {
            return PersistenceContext.ActivityRepository.GetActivityDates(idActivity, studentId).ToList();
        }

        public IEnumerable<ActivityDate> GetActivityDates(int idActivity)
        {
            return PersistenceContext.ActivityRepository.GetActivityDates(idActivity);
        }

        public IEnumerable<Student> GetActivityStudents(int idActivity)
        {
            return PersistenceContext.ActivityRepository.GetStudentsFromActivity(idActivity);
        }

        public Student GetStudent(int idStudent)
        {
            return PersistenceContext.StudentsRepository.GetEntity(idStudent);
        }

        public IEnumerable<Activity> GetTeacherActivities(string username)
        {
            throw new NotImplementedException();
        }
    }
}
