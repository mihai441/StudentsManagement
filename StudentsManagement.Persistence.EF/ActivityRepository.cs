using Microsoft.EntityFrameworkCore;
using StudentsManagement.Domain;
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

        public StudentsManagementDbContext StudentsManagementDbContext
        {
            get
            {
                return Context as StudentsManagementDbContext;
            }
        }
    }
}
