using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace StudentsManagement.Domain
{
    public class StudentActivityDetails
    {
        [Key]
        public int Id { get; set; }
        public int IdActivity { get; set; }
        public int IdStudent { get; set; }
        public DateTime Date { get; set; }
        public double Grade { get; set; }
        public bool Attendance { get; set; }
    }
}
