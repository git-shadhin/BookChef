using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookChef.Domain;
using BookChef.Domain.Classes;
using BookChef.Domain.DTO;
using BookChef.Domain.Enums;
using BookChef.Domain.Interfaces;

namespace BookChef.Persistence
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<BookDto> GetByTitle(string booktitle)
        {
            // stubbed - this should go to the database
            // and fetch the given book record

            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> GetByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> GetByIsbn(string isbn)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> GetByPublisher(string publisher)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> GetByStatus(BookStatus bookStatus)
        {
            throw new NotImplementedException();
        }

        public OperationResult CreateBook(BookDto newbookDto)
        {
            throw new NotImplementedException();
        }

        public OperationResult ChangeBookStatus(BookDto bookDto, BookStatus status)
        {
            throw new NotImplementedException();
        }

        public OperationResult DeleteBook(BookDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}
