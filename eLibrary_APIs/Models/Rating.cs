﻿namespace eLibrary_APIs.Models
{
    public class Rating
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string BookId { get; set; }
        public int NumberOfStar { get; set; }
    }
}
