﻿namespace StudentsManagement.Domain
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdActivityType { get; set; }
        public int IdTeacher{ get; set; }
    }
}
