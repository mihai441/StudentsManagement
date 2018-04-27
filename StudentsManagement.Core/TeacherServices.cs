using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Core
{
    class TeacherServices
    {
        private IPersistenceContext _persistenceContext;


        public TeacherServices(IPersistenceContext persistenceContext)
        {
            PersistenceContext = persistenceContext;
        }

        public IPersistenceContext PersistenceContext { get => _persistenceContext; set => _persistenceContext = value; }

        public IEnumerable<ActivityDate> GetActivityDates(int idActivity, int studentId)
        {
            return PersistenceContext.ActivityRepository.GetActivityDates(idActivity, studentId).ToList();
        }
    }
}
