using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface IActivityRepository : IRepository<Activity>
    {
        int GetProfessorId(int id);
        string GetProfessorName(int id);
        int GetActivityTypeId(int id);
        string GetActivityTypeName(int id);
        IEnumerable<ActivityDate> GetActivityDates(int activityId, string username);
        IEnumerable<ActivityDate> GetActivityDates(int activityId, int studentId);
        void AddActivityDate(DateTime Date, double Grade, bool Attendance, int ActivityId, int StudentId);
        ActivityDate GetActivityDate(int Id);
    }
}
