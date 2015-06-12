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
        private readonly BookChefEntities _context;

        public BookRepository(BookChefEntities db)
        {
            _context = db;
            AutomapperConfiguration();
        }

        public BookRepository()
        {
            _context = new BookChefEntities();
            AutomapperConfiguration();
        }

        public IEnumerable<BookDto> GetByTitle(string booktitle)
        {
            using (_context)
            {
                try
                {
                    var result = _context.Books.Where(books => books.Title.Contains(booktitle))
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
            using (_context)
            {
                try
                {
                    var result = _context.Books.Where(books => books.Author.Contains(author))
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

        public IEnumerable<BookDto> GetByIsbn(string isbn)
        {
            using (_context)
            {
                try
                {
                    var result = _context.Books.Where(books => books.Isbn.Contains(isbn))
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

        public IEnumerable<BookDto> GetByPublisher(string publisher)
        {
            using (_context)
            {
                try
                {
                    var result = _context.Books.Where(books => books.Publisher.Contains(publisher))
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

        public IEnumerable<BookDto> GetByStatus(string bookStatus)
        {
            using (_context)
            {
                try
                {
                    var result = _context.Books.Where(books => books.BookStatus.Label.Contains(bookStatus))
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

        private static void AutomapperConfiguration()
        {
            Mapper.CreateMap<Books, BookDto>();
        }
    }
}