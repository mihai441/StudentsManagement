using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        IEnumerable<Teacher> Teachers();
        Teacher GetTeacher(int id);
    }
}
