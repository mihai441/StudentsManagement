using Microsoft.EntityFrameworkCore;
using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Persistence.EF
{
    class TeachersRepository : Repository<Teacher>, ITeachersRepository
    {
        public TeachersRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Teacher> Teachers()
        {
            return StudentsManagementDbContext.Teachers.ToList();
        }

        public Teacher GetTeacher(int id)
        {
            return StudentsManagementDbContext.Teachers
                            .Where(s => s.Id == id)
                            .SingleOrDefault();
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
