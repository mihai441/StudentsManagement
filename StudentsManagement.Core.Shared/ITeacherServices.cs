﻿using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface ITeacherServices
    {
        IEnumerable<Activity> GetTeacherActivities(string username);
        IEnumerable<ActivityDate> GetActivityDates(int idActivity, int studentId);
        IEnumerable<ActivityDate> GetActivityDates(int idActivity);
        IEnumerable<Student> GetActivityStudents(int idActivity);
        Activity GetActivity(int idActivity);
        Student GetStudent(int idStudent);
        ActivityDate GetActivityDate(int idActivityDate);
        void AddActivityDate(DateTime date, double grade, bool attendance, int idActivity, int studentId);
        void UpdateActivityDate(ActivityDate oldActivityDate, ActivityDate newActivityDate );
    }
}
