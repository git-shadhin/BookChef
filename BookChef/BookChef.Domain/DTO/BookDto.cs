using BookChef.Domain.Classes;

namespace BookChef.Domain.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Status Status { get; set; }
    }
}