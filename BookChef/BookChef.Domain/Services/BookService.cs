using System.Collections.Generic;
using AutoMapper;
using BookChef.Domain.DTO;
using BookChef.Domain.Enums;
using BookChef.Domain.Interfaces;

namespace BookChef.Domain.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetByTitle(string title)
        {
            var bookDto = _bookRepository.GetByTitle(title);

            var books = Mapper.Map<IEnumerable<BookDto>, IEnumerable<Book>>(bookDto);

            return books;
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            var bookDto = _bookRepository.GetByAuthor(author);

            var books = Mapper.Map<IEnumerable<BookDto>, IEnumerable<Book>>(bookDto);

            return books;
        }

        public IEnumerable<Book> GetByIsbn(string isbn)
        {
            var bookDto = _bookRepository.GetByIsbn(isbn);

            var books = Mapper.Map<IEnumerable<BookDto>, IEnumerable<Book>>(bookDto);

            return books;
        }

        public IEnumerable<Book> GetByPublisher(string publisher)
        {
            var bookDto = _bookRepository.GetByPublisher(publisher);

            var books = Mapper.Map<IEnumerable<BookDto>, IEnumerable<Book>>(bookDto);

            return books;
        }

        public IEnumerable<Book> GetByStatus(BookStatus status)
        {
            var bookDto = _bookRepository.GetByStatus(status);

            var books = Mapper.Map<IEnumerable<BookDto>, IEnumerable<Book>>(bookDto);

            return books;
        }

        public OperationResult CreateBook(BookDto book)
        {
            var response = _bookRepository.CreateBook(book);

            return response;
        }
    }
}