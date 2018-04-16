using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class StudentActivityInfo
    {
        public int IdActivity { get; set; }

        public List<DateTime> Date { get; set; }

        public List<double> Grade { get; set; }

        public List<int> Attendance { get; set; }

        public string StatusMessage { get; set; }
    }
}
