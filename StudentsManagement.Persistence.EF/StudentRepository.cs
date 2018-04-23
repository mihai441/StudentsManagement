using Microsoft.EntityFrameworkCore;
using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Persistence.EF
{
    class StudentRepository : Repository<Student>, IStudentsRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

        public Student GetStudent(int id)
        {
            return StudentDbContext.Students
                .Where(s => s.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return StudentDbContext.Students.ToList();
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
