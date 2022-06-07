﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace csharp_cappef.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("course");
                });

            modelBuilder.Entity("CourseImage", b =>
                {
                    b.Property<int>("CourseImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseImageId"), 1L, 1);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("CourseImageId");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("course_image");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("FrequentedCoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsEnrolledStudentId")
                        .HasColumnType("int");

                    b.HasKey("FrequentedCoursesCourseId", "StudentsEnrolledStudentId");

                    b.HasIndex("StudentsEnrolledStudentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("StudentId");

                    b.ToTable("review");
                });

            modelBuilder.Entity("Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("student_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("student");
                });

            modelBuilder.Entity("CourseImage", b =>
                {
                    b.HasOne("Course", "Course")
                        .WithOne("CourseImage")
                        .HasForeignKey("CourseImage", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("Course", null)
                        .WithMany()
                        .HasForeignKey("FrequentedCoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsEnrolledStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Review", b =>
                {
                    b.HasOne("Student", "Student")
                        .WithMany("Reviews")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Course", b =>
                {
                    b.Navigation("CourseImage")
                        .IsRequired();
                });

            modelBuilder.Entity("Student", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
