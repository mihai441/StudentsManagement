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
                                           .Select(i => i.IdTeacher)
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
