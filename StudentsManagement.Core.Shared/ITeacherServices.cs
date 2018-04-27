using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface ITeacherServices
    {
        IEnumerable<Activity> GetTeacherActivities(string username);
        IEnumerable<ActivityDate> GetActivityDates(int idActivity, int studentId);
    }
}
