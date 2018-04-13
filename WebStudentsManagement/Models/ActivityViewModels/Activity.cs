using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class Activity
    {
        public int IdActivity { get; set; }

        public DateTime Date { get; set; }

        public int Grade { get; set; }

        public int Attendance { get; set; }

        public string StatusMessage { get; set; }
    }
}
