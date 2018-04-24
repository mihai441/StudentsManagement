using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentsManagement.Domain
{
    public class Activity : IdentityUser
    {
        
        public int IdAct { get; set; }
        public String Name { get; set; }
        public int TeacherId { get; set; }
    }
}
