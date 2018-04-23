using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsManagement.Persistence.EF
{
    class ActivityRepository : Repository<Activity>, IActivityRepository
    {

        public ActivityRepository(DetailsDbContext context) : base(context)
        {
        }

        public IEnumerable<Activity> GetActivities()
        {
            return ActivityDbContext.Activities.ToList();
                
        }
        


        public Activity GetActivity(int id)
        {
            return ActivityDbContext.Activities.Find(id);
        }

        public IEnumerable<Student> GetStudents(int id)
        {
            return ActivityDbContext.Activities
                                        .Where(b => b.Id == id)
                                        .Select(i => i.Students)
                                        .FirstOrDefault();
        }

        public int GetProfessor(int id)
        {
            return ActivityDbContext.Activities
                            .Where(b => b.Id == id)
                            .Select(i => i.TeacherId)
                            .FirstOrDefault();
}

        public DetailsDbContext ActivityDbContext
        {
            get
            {
                return Context as DetailsDbContext;
            }
        }
    }
}
