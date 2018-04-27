using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System.Collections.Generic;

namespace StudentsManagement.Core.Shared
{
    public interface IStudentServices
    {
        IPersistenceContext PersistenceContext { get; set; }
        IEnumerable<ActivityDate> GetActivityDates(int idActivity, string studentUsername);
        IEnumerable<Activity> GetUserActivities(string username);
        Activity GetActivity(int id);
    }
}
