using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence.EF
{
    public class PersistenceContext : IPersistenceContext
        
    {
        private readonly StudentsManagementDbContext _context;

        public PersistenceContext(StudentsManagementDbContext context)
        {
            _context = context;
            ActivityRepository = new ActivityRepository(_context);
            TeachersRepository = new TeachersRepository(_context);
            StudentsRepository = new StudentsRepository(_context);
        }

        public IActivityRepository ActivityRepository { get; set; }
        public IStudentActivityDetailsRepository ActivityDetailsRepository { get; set; }
        public ITeachersRepository TeachersRepository { get; set; }
        public IStudentsRepository StudentsRepository { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
