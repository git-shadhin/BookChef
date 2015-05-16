using BookChef.Domain.Enums;

namespace BookChef.Domain.DTO
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public BookStatus Status { get; set; }
    }
}