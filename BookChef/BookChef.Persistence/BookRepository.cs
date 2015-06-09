using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookChef.Domain.Interfaces;

namespace BookChef.Persistence
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Domain.DTO.BookDto> GetByTitle(string booktitle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.DTO.BookDto> GetByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.DTO.BookDto> GetByIsbn(string isbn)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.DTO.BookDto> GetByPublisher(string publisher)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.DTO.BookDto> GetByStatus(Domain.Classes.Status bookStatus)
        {
            throw new NotImplementedException();
        }

        public Domain.Classes.OperationResult CreateBook(Domain.DTO.BookDto newbookDto)
        {
            throw new NotImplementedException();
        }

        public Domain.Classes.OperationResult ChangeBookStatus(Domain.DTO.BookDto bookDto, Domain.Classes.Status status)
        {
            throw new NotImplementedException();
        }

        public Domain.Classes.OperationResult DeleteBook(Domain.DTO.BookDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}
