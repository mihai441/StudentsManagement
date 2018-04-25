using Microsoft.EntityFrameworkCore;
using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Persistence.EF
{
    class StudentsRepository : Repository<Student>, IStudentsRepository
    {
        public StudentsRepository(DbContext context) : base(context)
        {
        }

        public new Student GetEntity(int id)
        {

            return StudentsManagementDbContext.Students
                .Where(s => s.Id == id)
                .SingleOrDefault();
        }

        public new IEnumerable<Student> ListAll()
        {
            return StudentsManagementDbContext.Students.ToList();

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
