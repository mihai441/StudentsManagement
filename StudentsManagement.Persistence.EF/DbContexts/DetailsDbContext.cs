﻿using Microsoft.EntityFrameworkCore;
using StudentsManagement.Domain;

namespace StudentsManagement.Persistence.EF
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<StudentActivityDetails> StudentActivityDetails { get; set; }

    }
}