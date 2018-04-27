using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class TeacherActivityInfo
    {
        public IEnumerable<ActivityDate> ActivityDates { get; set; }
        public Student Student { get; set; }
        public Activity Activity { get; set; }
    }
}
