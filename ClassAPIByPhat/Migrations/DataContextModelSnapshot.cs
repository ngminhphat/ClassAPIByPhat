﻿// <auto-generated />
using System;
using ClassAPIByPhatByPhat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassAPIByPhat.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassAPIByPhatByPhat.Models.ClassAPIByPhatByPhat", b =>
                {
                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoursesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("ClassAPIByPhatByPhat");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("e2397972-8743-431a-9482-60292f08320e"),
                            CoursesId = new Guid("88738493-3a85-4443-8f6a-313453432192")
                        },
                        new
                        {
                            StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340d2"),
                            CoursesId = new Guid("9250d994-2558-4573-8465-417248667051")
                        });
                });

            modelBuilder.Entity("ClassAPIByPhatByPhat.Models.Courses", b =>
                {
                    b.Property<Guid?>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("9250d994-2558-4573-8465-417248667051"),
                            CourseName = "OOP",
                            Description = "Lap Trinh Huong Doi Tuong"
                        },
                        new
                        {
                            CourseId = new Guid("88738493-3a85-4443-8f6a-313453432192"),
                            CourseName = "Lap Trinh Web",
                            Description = "tach tach"
                        });
                });

            modelBuilder.Entity("ClassAPIByPhatByPhat.Models.Student", b =>
                {
                    b.Property<Guid?>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("e2397972-8743-431a-9482-60292f08320e"),
                            Name = "Minh Phat"
                        },
                        new
                        {
                            StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340d2"),
                            Name = "Le Minh Teo"
                        });
                });

            modelBuilder.Entity("ClassAPIByPhatByPhat.Models.ClassAPIByPhatByPhat", b =>
                {
                    b.HasOne("ClassAPIByPhatByPhat.Models.Courses", "Courses")
                        .WithMany("ClassAPIByPhatByPhat")
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassAPIByPhatByPhat.Models.Student", "Student")
                        .WithMany("ClassAPIByPhatByPhat")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ClassAPIByPhatByPhat.Models.Courses", b =>
                {
                    b.Navigation("ClassAPIByPhatByPhat");
                });

            modelBuilder.Entity("ClassAPIByPhatByPhat.Models.Student", b =>
                {
                    b.Navigation("ClassAPIByPhatByPhat");
                });
#pragma warning restore 612, 618
        }
    }
}
