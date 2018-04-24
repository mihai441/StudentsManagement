using StudentsManagement.Domain;
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
        int GetProfessorId(int id);
    }
}
