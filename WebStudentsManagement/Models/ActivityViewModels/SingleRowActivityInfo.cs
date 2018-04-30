using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class SingleRowActivityInfo
    {
        public string ActivityName { get; set; }
        public int ActivityId { get; set; }
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }
        public bool Attendance { get; set; }
    }
}
