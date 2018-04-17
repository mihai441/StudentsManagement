using System.Collections.Generic;

namespace StudentsManagement.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Activity> Activities { get; set; }
        public List<StudentActivityInfo> ActivitiesInfo { get; set; }
    }
}