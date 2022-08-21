using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<StudentCourse>(sc =>
            {
                sc.HasKey(sc => new { sc.StudentId, sc.CourseId });
            });

            modelBuilder.Entity<Homework>(h =>
            {
                h.HasOne(h => h.Student)
                .WithMany(h => h.HomeworkSubmissions);
            });

            modelBuilder.Entity<Homework>(h =>
            {
                h.HasOne(h => h.Course)
                .WithMany(h => h.HomeworkSubmissions);
            });

            modelBuilder.Entity<Course>(c =>
            {
                c.HasOne(c => c.Student)
                .WithMany(c => c.CourseEnrollments);
            });

            modelBuilder.Entity<Resource>(c =>
            {
                c.HasOne(c => c.Course)
                .WithMany(c => c.Resources);
            });
        }
    }
}
