using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace StudentsManagement.Domain
{
    public class StudentActivityDetails
    {
        [Key]
        public int Id { get; set; }

        public int ActivityId { get; set; }
        public virtual Activity Activity{ get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
