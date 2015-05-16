using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookChef.Domain.DTO;
using BookChef.Domain.Exceptions;
using BookChef.Domain.Interfaces;
using BookChef.Domain.Services;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookChef.Domain.Test
{
    [TestClass]
    public class BookServiceTests
    {
        private const string ValidTitle = "Odyssey";
        private const string ValidAuthor = "Homer";
        private const string ValidIsbn = "123456";
        private const string ValidPublisher = "Someone";
        private const string InvalidTitle = "InvalidTitle";
        private const string InvalidAuthor = "InvalidAuthor";
        private const string InvalidIsbn = "InvalidIsbn";
        private const string InvalidPublisher = "InvalidPublisher";

        private readonly List<BookDto> _books = new List<BookDto>
        {
            new BookDto
            {
                BookId = 1,
                Title = ValidTitle,
                Isbn = ValidIsbn,
                Publisher = ValidPublisher,
                Author = ValidAuthor
            }
        };

        private IBookRepository _bookRepository;
        private BookService _bookService;

        [TestInitialize]
        public void Initialize()
        {
            _bookRepository = A.Fake<IBookRepository>();

            A.CallTo(() => _bookRepository.GetByTitle(ValidTitle))
                .Returns(_books);
            A.CallTo(() => _bookRepository.GetByAuthor(ValidAuthor))
                .Returns(_books);
            A.CallTo(() => _bookRepository.GetByIsbn(ValidIsbn))
                .Returns(_books);
            A.CallTo(() => _bookRepository.GetByPublisher(ValidPublisher))
                .Returns(_books);

            A.CallTo(() => _bookRepository.GetByTitle(InvalidTitle))
                .Throws<BookNotFoundException>();
            A.CallTo(() => _bookRepository.GetByAuthor(InvalidAuthor))
                .Throws<BookNotFoundException>();
            A.CallTo(() => _bookRepository.GetByIsbn(InvalidIsbn))
                .Throws<BookNotFoundException>();
            A.CallTo(() => _bookRepository.GetByPublisher(InvalidPublisher))
                .Throws<BookNotFoundException>();

            Mapper.CreateMap<BookDto, Book>();

            _bookService = new BookService(_bookRepository);
        }

        [TestMethod]
        public void GetByTitle_ValidTitle_ReturnsBooks()
        {
            var result = _bookService.GetByTitle(ValidTitle);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Title == ValidTitle));
        }

        [TestMethod, ExpectedException(typeof (BookNotFoundException))]
        public void GetByTitle_InvalidTitle_ThrowsException()
        {
            var books = _bookService.GetByTitle(InvalidTitle);
        }

        [TestMethod]
        public void GetByAuthor_ValidAuthor_ReturnsBooks()
        {
            var result = _bookService.GetByAuthor(ValidAuthor);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Author == ValidAuthor));
        }

        [TestMethod, ExpectedException(typeof (BookNotFoundException))]
        public void GetByAuthor_InvalidAuthor_ThrowsException()
        {
            var books = _bookService.GetByAuthor(InvalidAuthor);
        }

        [TestMethod]
        public void GetByIsbn_ValidIsbn_ReturnsBooks()
        {
            var result = _bookService.GetByIsbn(ValidIsbn);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Isbn == ValidIsbn));
        }

        [TestMethod, ExpectedException(typeof (BookNotFoundException))]
        public void GetByIsbn_InvalidIsbn_ThrowsException()
        {
            var books = _bookService.GetByIsbn(InvalidIsbn);
        }

        [TestMethod]
        public void GetByPublisher_ValidPublisher_ReturnsBooks()
        {
            var result = _bookService.GetByPublisher(ValidPublisher);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Publisher == ValidPublisher));
        }

        [TestMethod, ExpectedException(typeof (BookNotFoundException))]
        public void GetByPublisher_InvalidPublisher_ThrowsException()
        {
            var books = _bookService.GetByPublisher(InvalidPublisher);
        }
    }
}