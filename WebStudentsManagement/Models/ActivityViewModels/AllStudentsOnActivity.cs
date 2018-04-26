using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class AllStudentsOnActivity
    {
        public IEnumerable<Student> Students { get; set; }

    }
}
