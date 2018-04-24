using StudentsManagement.Domain;
using System.Collections.Generic;
using System.Linq;

namespace StudentsManagement.Persistence.EF
{
    class ActivityRepository : Repository<Activity>, IActivityRepository
    {

        public ActivityRepository(StudentsManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<Activity> GetActivities()
        {
            return StudentsManagementDbContext.Activities.ToList();
                
        }

        public Activity GetActivity(int id)
        {
            return StudentsManagementDbContext.Activities.Find(id);
        }

        //public IEnumerable<Student> GetStudents(int id)
        //{
            
        //    return StudentsManagementDbContext.Activities
        //                                .Where(b => b.IdAct == id)
        //                                .Select(i => i.Students)
        //                                .FirstOrDefault();
        //}

        public int GetProfessorId(int id)
        {
            //return StudentsManagementDbContext.Activities
            //                .Where(b => b.IdAct == id)
            //                .Select(i => i.TeacherId)
            //                .FirstOrDefault();
            return 0;
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
