using Microsoft.EntityFrameworkCore;
using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Persistence.EF
{
    class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Teacher> Teachers()
        {
            return StudentDbContext.Teachers.ToList();
        }

        public Teacher GetTeacher(int id)
        {
            return StudentDbContext.Teachers
                            .Where(s => s.Id == id)
                            .SingleOrDefault();
        }

        public UsersDbContext StudentDbContext
        {
            get
            {
                return Context as UsersDbContext;
            }
        }
    }
}
