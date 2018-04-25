﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StudentsManagement.Persistence.EF;
using System;

namespace WebStudentsManagement.Migrations
{
    [DbContext(typeof(StudentsManagementDbContext))]
    [Migration("20180425100223_NewActivityModel")]
    partial class NewActivityModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentsManagement.Domain.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("IdActivityType");

                    b.Property<int>("IdTeacher");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("StudentsManagement.Domain.ActivityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nume");

                    b.HasKey("Id");

                    b.ToTable("ActivityTypes");
                });

            modelBuilder.Entity("StudentsManagement.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentsManagement.Domain.StudentActivityDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Attendance");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Grade");

                    b.Property<int>("IdActivity");

                    b.Property<int>("IdStudent");

                    b.HasKey("Id");

                    b.ToTable("StudentActivityDetails");
                });

            modelBuilder.Entity("StudentsManagement.Domain.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}