using System.Collections.Generic;
using BookChef.Domain.Classes;
using BookChef.Domain.DTO;
using BookChef.Domain.Enums;

namespace BookChef.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<BookDto> GetByTitle(string booktitle);
        IEnumerable<BookDto> GetByAuthor(string author);
        IEnumerable<BookDto> GetByIsbn(string isbn);
        IEnumerable<BookDto> GetByPublisher(string publisher);
        IEnumerable<BookDto> GetByStatus(BookStatus bookStatus);
        OperationResult CreateBook(BookDto newbookDto);
        OperationResult ChangeBookStatus(BookDto bookDto, BookStatus status);
    }
}