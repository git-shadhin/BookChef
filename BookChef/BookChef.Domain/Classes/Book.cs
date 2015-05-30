namespace BookChef.Domain.Classes
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Isbn { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public Status Status { get; set; }

        public int? PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}