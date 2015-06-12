using System;
using BookChef.Domain.Classes;

namespace BookChef.Domain.DTO
{
    public class BookDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Status { get; set; }
    }
}