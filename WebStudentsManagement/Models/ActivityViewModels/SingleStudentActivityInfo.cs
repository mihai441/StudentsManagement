using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class SingleStudentActivityInfo
    {
        public int IdActivity { get; set; }

        public string ActivityName { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public DateTime Date { get; set; }

        public double Grade { get; set; }

        public bool Attendance { get; set; }
    }
}
