﻿using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public string? Education { get; set; }
        public string? Biography { get; set; }
        public bool IsActive { get; set; } = true;
    }
}