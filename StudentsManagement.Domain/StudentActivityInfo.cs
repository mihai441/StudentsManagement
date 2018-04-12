using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class StudentActivityInfo
    {
        public int IdActivity { get; set; }
        public int IdStudent { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }
        public int Attendance { get; set; }
    }
}
