﻿using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStudentsManagement.Models.ManageViewModels
{
    public class AddStudentToActivity
    {
        public Activity Activity { get; set; }
        public IEnumerable<Student> StudentList { get; set; }
    }
}
