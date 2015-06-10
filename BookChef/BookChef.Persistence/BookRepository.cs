using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookChef.Domain.Classes;
using BookChef.Domain.DTO;
using BookChef.Domain.Interfaces;

namespace BookChef.Persistence
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<BookDto> GetByTitle(string booktitle)
        {
            Mapper.CreateMap<Books, BookDto>();

            var context = new BookChefEntities();
            var result = context.Books.Where(books => books.Title.Contains(booktitle)).ToList();
            var resultDto = Mapper.Map<List<Books>, List<BookDto>>(result);

            return resultDto;
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

        public IEnumerable<BookDto> GetByStatus(Domain.Classes.Status bookStatus)
        {
            throw new NotImplementedException();
        }

        public OperationResult CreateBook(BookDto newbookDto)
        {
            throw new NotImplementedException();
        }

        public OperationResult ChangeBookStatus(BookDto bookDto, Domain.Classes.Status status)
        {
            throw new NotImplementedException();
        }

        public OperationResult DeleteBook(BookDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}