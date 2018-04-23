using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentsManagement.Domain
{
    public class Activity : IdentityUser
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public List<DateTime> Calendar { get; set; }
        public int TeacherId { get; set; }
    }
}
