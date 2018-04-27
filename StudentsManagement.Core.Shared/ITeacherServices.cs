using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface ITeacherServices
    {
        IEnumerable<ActivityDate> GetActivityDates(int idActivity, int studentId);
    }
}
