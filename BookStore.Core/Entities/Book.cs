using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ISBN { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string? CoverImageUrl { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; } = null!;

        public ICollection<BookReview> Reviews { get; set; } = new List<BookReview>();
    }
}
