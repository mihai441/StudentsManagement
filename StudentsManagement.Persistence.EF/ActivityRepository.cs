﻿using Microsoft.EntityFrameworkCore;
using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsManagement.Persistence.EF
{
    class ActivityRepository : Repository<Activity>, IActivityRepository
    {

        public ActivityRepository(DbContext context) : base(context)
        {
        }      
        public int GetProfessorId(int id)
        {
            return StudentsManagementDbContext.Activities
                                           .Where(b => b.Id == id)
                                           .Select(i => i.TeacherId)
                                           .FirstOrDefault();
        }

        public string GetProfessorName(int id)
        {
            return StudentsManagementDbContext.Teachers
                                           .Where(b => b.Id == GetProfessorId(id))
                                           .Select(i => i.Name)
                                           .FirstOrDefault();
        }

        public int GetActivityTypeId(int id)
        {
            return StudentsManagementDbContext.Activities
                                           .Where(b => b.Id == id)
                                           .Select(i => i.ActivityTypeId)
                                           .FirstOrDefault();
        }

        public string GetActivityTypeName(int id)
        {
            return StudentsManagementDbContext.ActivityTypes
                                           .Where(b => b.Id == GetActivityTypeId(id))
                                           .Select(i => i.Name)
                                           .FirstOrDefault();
        }

        public IEnumerable<ActivityDate> GetActivityDates(int activityId, string userNameStudent)
        {
            return StudentsManagementDbContext.ActivityDates
                                            .Where(b => b.ActivityId == activityId)
                                            .Where(b => b.Student.Username == userNameStudent);
                                            
        }

        public void AddActivityDate(DateTime Date, double Grade, bool Attendance, int ActivityId, int idStudent)
        {
            StudentsManagementDbContext.ActivityDates.Add(new ActivityDate { Date = Date, Grade = Grade, Attendance = Attendance, ActivityId = ActivityId, StudentId = idStudent});
        }

        public ActivityDate GetActivityDate(int Id)
        {
            return StudentsManagementDbContext.ActivityDates
                .Where(b => b.Id == Id)
                .SingleOrDefault();
        }

        public IEnumerable<ActivityDate> GetActivityDates(int activityId, int studentId)
        {
            return StudentsManagementDbContext.ActivityDates
                                           .Where(b => b.ActivityId == activityId)
                                           .Where(b => b.StudentId == studentId)
                                           .ToList();
        }

        public IEnumerable<Activity> GetUserActivities(string username)
        {
            List<StudentActivityDetails> activityDetails = StudentsManagementDbContext.StudentActivityDetails
                .Where(b => b.Student.Username == username).ToList();
            List<Activity> activities = new List<Activity>();
            foreach(var activityDetail in activityDetails)
            {
                activities.Add(activityDetail.Activity);
            }
            return activities;

        }

        public Activity GetActivityByName(string name)
        {
            return StudentsManagementDbContext.Activities
                .Where(b => b.Name == name)
                .SingleOrDefault();
        }

        public IEnumerable<ActivityDate> GetActivityDates(int activityId)
        {
            return StudentsManagementDbContext.ActivityDates
                                         .Where(b => b.ActivityId == activityId)
                                         .ToList();
        }

        public IEnumerable<Student> GetStudentsFromActivity(int idActivity)
        {
            return StudentsManagementDbContext.StudentActivityDetails
                .Where(b => b.ActivityId == idActivity)
                .Select(i => i.Student).ToList();

        }

        public StudentsManagementDbContext StudentsManagementDbContext
        {
            get
            {
                return Context as StudentsManagementDbContext;
            }
        }
    }
}
