using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookChef.Domain.DTO;
using BookChef.Domain.Interfaces;

namespace BookChef.Persistence
{
    public class BookRepository : IBookRepository
    {
        public BookDto GetByTitle(string booktitle)
        {
            var bookDto = new BookDto();

            // stubbed - this should go to the database
            // and fetch the given book record

            bookDto.Title = booktitle;

            if (booktitle != "validtitle") return bookDto;
            bookDto.BookId = 1;
            bookDto.Isbn = "123-456";
            bookDto.Publisher = "Books Publisher";
            bookDto.Author = "John Smith";

            return bookDto;
        }
    }
}
