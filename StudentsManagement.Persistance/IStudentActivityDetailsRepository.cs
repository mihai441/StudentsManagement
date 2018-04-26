using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface IStudentActivityDetailsRepository : IRepository<StudentActivityDetails>
    {
        IEnumerable<ActivityDate> GetActivityDates(int activityId, int idStudent);
    }
}
