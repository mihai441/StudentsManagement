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


        public StudentsManagementDbContext StudentsManagementDbContext
        {
            get
            {
                return Context as StudentsManagementDbContext;
            }
        }
    }
}
