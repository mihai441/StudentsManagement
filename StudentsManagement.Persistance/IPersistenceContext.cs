using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface IPersistenceContext
    {
        int Complete();
        void Dispose();
        IActivityRepository ActivityRepository { get; set; }
        IStudentActivityDetailsRepository ActivityDetailsRepository { get; set; }
        ITeachersRepository TeachersRepository { get; set; }
        IStudentsRepository StudentsRepository { get; set; }
    }
}
