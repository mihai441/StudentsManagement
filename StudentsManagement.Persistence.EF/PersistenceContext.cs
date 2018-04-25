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

        public PersistenceContext(){}


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
                options.UseSqlServer(Configuration.GetConnectionString("StudentsManagementConnection")));

            InitializeDbContext(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder builder)
        {
            throw new NotImplementedException();
        }

        public void InitializeData(IServiceProvider serviceProvider)
        {
            InitializeDbContext(serviceProvider);


            if (StudentsRepository.ListAll().Count() == 0)
            {
                var stud1 = new Student
                {
                    Id = 0,
                    Name = "Gheorghe"
                };

                var stud2 = new Student
                {
                    Id = 1,
                    Name = "Stefanescu"
                };

                StudentsRepository.Add(stud1);
                StudentsRepository.Add(stud2);
                //}
            }

            if (TeachersRepository.ListAll().Count() == 0)
            {
                var teacher1 = new Teacher
                {
                    Id = 0,
                    Name = "Costache"
                };

                var teacher2 = new Teacher
                {
                    Id = 1,
                    Name = "Ofelia"
                };

                TeachersRepository.Add(teacher1);
                TeachersRepository.Add(teacher2);
                //}
            }

            if (ActivityRepository.ListAll().Count() == 0)
            {
                var activity1 = new Activity
                {
                    Id = 0,
                    Name = "Sisteme de Operare",
                    Description = "Studiu al sistemelor de operare",
                    IdActivityType = 0,
                    IdTeacher = 0
                };

                var activity2 = new Activity
                {
                    Id = 1,
                    Name = "Arhitectura Calculatoarelor",
                    Description = "Arhitectura calc",
                    IdActivityType = 1,
                    IdTeacher = 1
                };

                ActivityRepository.Add(activity1);
                ActivityRepository.Add(activity2);

            }
        }
    }
}
