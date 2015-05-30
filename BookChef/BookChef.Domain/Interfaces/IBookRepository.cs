﻿using System.Collections.Generic;
using BookChef.Domain.Classes;
using BookChef.Domain.DTO;

namespace BookChef.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<BookDto> GetByTitle(string booktitle);
        IEnumerable<BookDto> GetByAuthor(string author);
        IEnumerable<BookDto> GetByIsbn(string isbn);
        IEnumerable<BookDto> GetByPublisher(string publisher);
        IEnumerable<BookDto> GetByStatus(Status bookStatus);
        OperationResult CreateBook(BookDto newbookDto);
        OperationResult ChangeBookStatus(BookDto bookDto, Status status);
        OperationResult DeleteBook(BookDto bookDto);
    }
}