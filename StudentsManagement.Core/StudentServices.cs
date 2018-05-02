using Microsoft.Extensions.DependencyInjection;
using StudentsManagement.Core.Shared;
using Microsoft.AspNetCore.Builder;
using StudentsManagement.Persistence;
using System.Security.Claims;
using StudentsManagement.Domain;
using System.Collections.Generic;
using System.Linq;

namespace StudentsManagement.Core
{
    class StudentServices : IStudentServices
    {
        private IPersistenceContext _persistenceContext;


        public StudentServices(IPersistenceContext persistenceContext)
        {
            PersistenceContext = persistenceContext;
        }

        public IPersistenceContext PersistenceContext { get => _persistenceContext; set => _persistenceContext = value; }

        public IEnumerable<ActivityDate> GetActivityDates(int idActivity, string studentUsername)
        {
           return PersistenceContext.ActivityRepository.GetActivityDates(idActivity, studentUsername).ToList();
        }

        public Activity GetActivity(int id)
        {
            if(id > 0 )
                return PersistenceContext.ActivityRepository.GetEntity(id);
            return null;
        }

        public IEnumerable<Activity> GetUserActivities(string username)
        { 

            return _persistenceContext.ActivityRepository.GetUserActivities(username);
                
        }

        public void AddStudent(ApplicationUser user)
        {
            if (user != null)
            {
                var stud = new Student
                {
                    Name = user.Email,
                    Username = user.Email
                };

                PersistenceContext.StudentsRepository.Add(stud);
                PersistenceContext.Complete();
            }

        }
    }
}
