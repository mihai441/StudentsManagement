using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentsManagement.Domain
{
    public class Activity : IdentityUser
    {
        public int IdAct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdTeacher{ get; set; }
    }
}
