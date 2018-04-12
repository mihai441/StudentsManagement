using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentsManagement.Domain
{
    public class Activity
    {
        public String Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public List<DateTime> Calendar { get; set; }
        public Teacher Owner { get; set; }
    }
}
