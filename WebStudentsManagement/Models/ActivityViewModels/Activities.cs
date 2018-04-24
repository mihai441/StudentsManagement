using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class Activities
    {
        public int IdActivity { get; set; }

        public string ActivityName { get; set; }

        public string ActivityType { get; set; }

        public string ActivityDescription { get; set; }

        public string StatusMessage { get; set; }
    }
}
