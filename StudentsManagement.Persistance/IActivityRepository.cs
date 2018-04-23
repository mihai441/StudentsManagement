﻿using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface IActivityRepository : IRepository<Activity>
    {
        IEnumerable<Activity> GetActivities();
        Activity GetActivity(int id);
        IEnumerable<Student> GetStudents(int id);
        int GetProfessor(int id);
    }
}