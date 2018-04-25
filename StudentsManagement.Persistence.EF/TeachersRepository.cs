using Microsoft.EntityFrameworkCore;
using StudentsManagement.Domain;
using System.Collections.Generic;
using System.Linq;

namespace StudentsManagement.Persistence.EF
{
    class TeachersRepository : Repository<Teacher>, ITeachersRepository
    {
        public TeachersRepository(DbContext context) : base(context)
        {
        }

        public new IEnumerable<Teacher> ListAll()
        {
            return StudentsManagementDbContext.Teachers.ToList();
        }

        public new Teacher GetEntity(int id)
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
