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


        public StudentsManagementDbContext StudentsManagementDbContext
        {
            get
            {
                return Context as StudentsManagementDbContext;
            }
        }
    }
}
