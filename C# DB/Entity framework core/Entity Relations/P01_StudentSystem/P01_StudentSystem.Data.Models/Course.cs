using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.StudentsEnrolled = new HashSet<Student>();
            this.Resources = new HashSet<Resource>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(Common.CourseNameMaxLenght)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Student))]
        public virtual ICollection<Student> StudentsEnrolled { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(Resource))]
        public virtual ICollection<Resource> Resources { get; set; }
        public Resource Resource { get; set; }

        [ForeignKey(nameof(Homework))]
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
        public Homework Homework { get; set; }
    }
}
