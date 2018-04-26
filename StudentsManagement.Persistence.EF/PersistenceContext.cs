using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsManagement.Domain;
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

        public PersistenceContext() {}


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
            options.UseLazyLoadingProxies()
            .UseSqlServer(Configuration.GetConnectionString("StudentsManagementConnection"),              
                b => b.MigrationsAssembly("StudentsManagement.Persistence.EF")));

            InitializeDbContext(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder builder)
        {
            throw new NotImplementedException();
        }

        public void InitializeData(IServiceProvider serviceProvider)
        {
            InitializeDbContext(serviceProvider);

            ActivityType course = new ActivityType {Name = "Course" };
            ActivityType lab = new ActivityType { Name = "Laboratory" };

            if (StudentsRepository.ListAll().Count() == 0)
            {
                var stud1 = new Student
                {
                    Name = "Gheorghe"
                };

                var stud2 = new Student
                {
                    Name = "Stefanescu"
                };

                StudentsRepository.Add(stud1);
                StudentsRepository.Add(stud2);
                
            }

            var teacher1 = TeachersRepository.GetTeacherByName("Costache");
            if (teacher1 == null)
            {
                teacher1 = new Teacher
                {
                    Name = "Costache"
                };
                TeachersRepository.Add(teacher1);
            }

            var teacher2 = TeachersRepository.GetTeacherByName("Ofelia");
            if (teacher2 == null)
            {
                teacher2 = new Teacher
                {
                    Name = "Ofelia"
                };
                TeachersRepository.Add(teacher2);
            }         

            
            if (ActivityRepository.ListAll().Count() == 0)
            {
                var activity1 = new Activity
                {
                    Name = "Sisteme de Operare",
                    Description = "Studiu al SO",
                    Owner = teacher1,
                    ActivityType = course
                    
                };

                var activity2 = new Activity
                {
                    Name = "Arhitectura Calculatoarelor",
                    Description = "Arhitectura calc",
                    ActivityType = lab,
                    Owner = teacher2
                };

                ActivityRepository.Add(activity1);
                ActivityRepository.Add(activity2);
            }

            Complete();
            
        }
    }
}
