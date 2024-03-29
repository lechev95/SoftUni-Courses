﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentingSystem.Infrastructure.Data
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(150)]
        public string Address { get; set; } = null!;
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;
        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; } = null!;
        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal PricePerMonth { get; set; }
        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        [ForeignKey(nameof(Agent))]
        [Required]
        public int AgentId { get; set; }
        public Agent Agent { get; set; }
        [ForeignKey(nameof(Renter))]
        public string? RenterId { get; set; }
        public IdentityUser? Renter { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
