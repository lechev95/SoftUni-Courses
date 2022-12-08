﻿namespace LibraryManagementSystem.Core.Models.Book
{
    public class BookHomeModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public byte[] Cover { get; set; } = null!;
    }
}
