using System.Collections.Generic;

namespace StudentsManagement.Domain
{
    public class Teacher
    {
        public string Name { get; set; }
        public List<Activity> Activities { get; set; }
    }
}