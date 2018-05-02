﻿using StudentsManagement.Core.Shared;
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

        public void AddActivityDate(ActivityDate newActivityDate)
        {
            PersistenceContext.ActivityRepository.AddActivityDate(newActivityDate);
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

        public ActivityDate GetActivityDate(int idActivityDate, int idStudent)
        {
            return PersistenceContext.ActivityRepository.GetActivityDate(idActivityDate, idStudent);
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
            return PersistenceContext.ActivityRepository.GetTeacherActivities(username);
        }

        public void UpdateActivityDate(ActivityDate oldActivityDate, ActivityDate newActivityDate)
        {
            var toBeUpdatedRecord = PersistenceContext.ActivityRepository.GetActivityDate(oldActivityDate.Id);

            toBeUpdatedRecord.Id = newActivityDate.Id;
            toBeUpdatedRecord.Grade = newActivityDate.Grade;
            toBeUpdatedRecord.Date = newActivityDate.Date;
            toBeUpdatedRecord.Attendance = newActivityDate.Attendance;
            toBeUpdatedRecord.Student = newActivityDate.Student;
            toBeUpdatedRecord.Activity = newActivityDate.Activity;
            PersistenceContext.Complete();
            
        }
    }
}
