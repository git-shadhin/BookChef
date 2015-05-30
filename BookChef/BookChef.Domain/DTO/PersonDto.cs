using BookChef.Domain.Classes;
using System.Collections.Generic;

namespace BookChef.Domain.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Birthday { get; set; }

        public string ControlNumber { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}