using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class Activities
    {
        public List<int> IdActivities { get; set; }

        public List<string> ActivitiesName { get; set; }

        public string StatusMessage { get; set; }
    }
}
