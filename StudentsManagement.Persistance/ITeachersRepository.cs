using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface ITeachersRepository : IRepository<Teacher>
    {
        IEnumerable<Teacher> Teachers();
        Teacher GetTeacher(int id);
    }
}
