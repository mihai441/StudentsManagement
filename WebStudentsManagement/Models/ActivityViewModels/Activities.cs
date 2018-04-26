using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class Activities
    {
        public IEnumerable<Activity> ActivitiesList { get; set; }
        public string StatusMessage { get; set; }
    }
}
