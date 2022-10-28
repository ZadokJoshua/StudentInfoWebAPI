using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentInfoAPI.DTOs;
using StudentInfoAPI.Entities;
using static StudentInfoAPI.Entities.UserApiKeys;

namespace StudentInfoAPI.Data
{
    public class StudentInfoDbContext : IdentityUserContext<IdentityUser>
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<CourseStudent> CourseStudent { get; set; } = null!;
        public DbSet<UserApiKey> UserApiKeys { get; set; } = null!;

        public StudentInfoDbContext(DbContextOptions<StudentInfoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CourseStudent>()
                .HasOne(s => s.Student)
                .WithMany(cs => cs.CourseStudent)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(c => c.Course)
                .WithMany(cs => cs.CourseStudent)
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Course>()
                .HasData(
                new Course
                {
                    Id = 1,
                    Name = "Chemistry"
                },
                new Course
                {
                    Id = 2,
                    Name = "Physics"
                }
                );

            modelBuilder.Entity<Student>()
                .HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Zadok Joshua",
                    MatricNumber = "2017/345"
                },
                new Student()
                {
                    Id = 2,
                    Name = "Trinity Ikpe",
                    MatricNumber = "2017/343"
                },
                new Student()
                {
                    Id = 3,
                    Name = "James Sam",
                    MatricNumber = "2017/343"
                });

            modelBuilder.Entity<CourseStudent>()
                .HasData(
                new CourseStudent
                {
                    Id = 1,
                    StudentId = 1,
                    CourseId = 1
                },
                new CourseStudent
                {
                    Id = 2,
                    StudentId = 2,
                    CourseId = 1
                },
                new CourseStudent
                {
                    Id = 3,
                    StudentId = 2,
                    CourseId = 2
                },
                new CourseStudent
                {
                    Id = 4,
                    StudentId = 3,
                    CourseId = 2
                });
        }
    }
}
