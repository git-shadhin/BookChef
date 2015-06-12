using System.Collections.Generic;

namespace BookChef.Domain.DTO
{
    public class PersonDto
    {
        public long Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Birthday { get; set; }

        public string ControlNumber { get; set; }

        public virtual ICollection<BookDto> Books { get; set; }
    }
}