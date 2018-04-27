using System.Collections.Generic;

namespace StudentsManagement.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        public virtual ICollection<StudentActivityDetails> SubscribedActivities { get; set; }
        public virtual ICollection<ActivityDate> ActivityDetails { get; set; }
    }
}