using System.Collections.Generic;
using BookChef.Domain.Classes;
using BookChef.Domain.DTO;
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

        public IEnumerable<BookDto> GetByTitle(string title)
        {
            var bookDto = _bookRepository.GetByTitle(title);
            return bookDto;
        }

        public IEnumerable<BookDto> GetByAuthor(string author)
        {
            var bookDto = _bookRepository.GetByAuthor(author);
            return bookDto;
        }

        public IEnumerable<BookDto> GetByIsbn(string isbn)
        {
            var bookDto = _bookRepository.GetByIsbn(isbn);
            return bookDto;
        }

        public IEnumerable<BookDto> GetByPublisher(string publisher)
        {
            var bookDto = _bookRepository.GetByPublisher(publisher);
            return bookDto;
        }

        public IEnumerable<BookDto> GetByStatus(string status)
        {
            var bookDto = _bookRepository.GetByStatus(status);
            return bookDto;
        }

        public OperationResult CreateBook(BookDto book)
        {
            var response = _bookRepository.CreateBook(book);
            return response;
        }

        public OperationResult ChangeBookStatus(BookDto bookDto, string status)
        {
            var response = _bookRepository.ChangeBookStatus(bookDto, status);
            return response;
        }

        public OperationResult DeleteBook(BookDto bookDto)
        {
            var response = _bookRepository.DeleteBook(bookDto);
            return response;
        }
    }
}