using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.HomeworkSubmissions = new HashSet<Homework>();
            this.CourseEnrollments = new HashSet<Course>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(Common.StudentNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(Common.StudentPhoneMaxLength)]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        [ForeignKey(nameof(Homework))]
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
        public Homework Homework { get; set; }

        [ForeignKey(nameof(Course))]
        public virtual ICollection<Course> CourseEnrollments { get; set; }
        public Course Course { get; set; }
    }
}
