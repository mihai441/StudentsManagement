using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class StudentActivityDetails
    {
        public int IdActivity { get; set; }
        public List<int> IdStudent { get; set; }
        public List<DateTime> Date { get; set; }
        public List<double> Grade { get; set; }
        public List<bool> Attendance { get; set; }
    }
}
