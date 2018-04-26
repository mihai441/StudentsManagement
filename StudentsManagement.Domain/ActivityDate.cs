using System;

namespace StudentsManagement.Domain
{
    public class ActivityDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Grade { get; set; }
        public bool Attendance { get; set; }

        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
