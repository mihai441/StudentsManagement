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
        public string ActivityName;
        public string StudentName;
        public string IdActivity;
        public string StudentId;
    }
}
