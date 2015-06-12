using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

            using (var context = new BookChefEntities())
            {
                try
                {
                    var result = context.Books.Where(books => books.Title.Contains(booktitle))
                        .AsQueryable()
                        .Project()
                        .To<BookDto>()
                        .ToList();
                    return result;
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
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

        public IEnumerable<BookDto> GetByStatus(string bookStatus)
        {
            throw new NotImplementedException();
        }

        public OperationResult CreateBook(BookDto newbookDto)
        {
            throw new NotImplementedException();
        }

        public OperationResult ChangeBookStatus(BookDto bookDto, string status)
        {
            throw new NotImplementedException();
        }

        public OperationResult DeleteBook(BookDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}