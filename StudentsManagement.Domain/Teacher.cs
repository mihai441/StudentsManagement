using System.Collections.Generic;

namespace StudentsManagement.Domain
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}