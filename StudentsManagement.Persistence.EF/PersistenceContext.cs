using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Persistence.EF
{
    public class PersistenceContext : IPersistenceContext        
    {
       
        private StudentsManagementDbContext _context;  
       

        public IActivityRepository ActivityRepository { get; set; }
        public IStudentActivityDetailsRepository ActivityDetailsRepository { get; set; }
        public ITeachersRepository TeachersRepository { get; set; }
        public IStudentsRepository StudentsRepository { get; set; }

        private void InitializeDbContext(IServiceProvider provider)
        {
            if (_context == null)
            {
                _context = provider.GetRequiredService<StudentsManagementDbContext>();
            }
            ActivityRepository = new ActivityRepository(_context);
            TeachersRepository = new TeachersRepository(_context);
            StudentsRepository = new StudentsRepository(_context);
        }

        public PersistenceContext()
        {

           
        }
        public int Complete()
        {
            int retVal = 0;
            if (_context != null)
            {
                retVal = _context.SaveChanges();
            }

            return retVal;
        }       

        public void Dispose()
        {
            if (_context != null)
            { 
                _context.Dispose();
            }
        }

        public void InitializeContext(IServiceCollection services, IConfiguration Configuration)
        { 
            services.AddDbContext<StudentsManagementDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ManagementDb")));

            InitializeDbContext(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder builder)
        {
            throw new NotImplementedException();
        }

        public void InitializeData(IServiceProvider serviceProvider)
        {
            InitializeDbContext(serviceProvider);
            if (StudentsRepository.GetStudents().Count() == 0)
            {

            }
        }
    }
}
