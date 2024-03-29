﻿using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseServiceModel
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Address { get; init; } = null!;
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;
        [Display(Name = "Price per month")]
        public decimal PricePerMonth { get; init; }
        [Display(Name = "Is rented")]
        public bool IsRented { get; init; }
    }
}
