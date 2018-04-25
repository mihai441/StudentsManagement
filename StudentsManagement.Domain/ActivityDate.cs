using System;

namespace StudentsManagement.Domain
{
    public class ActivityDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Grade { get; set; }
        public bool Attendance { get; set; }
    }
}
