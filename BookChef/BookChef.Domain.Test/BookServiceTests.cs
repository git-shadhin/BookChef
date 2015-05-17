using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookChef.Domain.Classes;
using BookChef.Domain.DTO;
using BookChef.Domain.Enums;
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
                Id = 1,
                Title = ValidTitle,
                Isbn = ValidIsbn,
                Publisher = ValidPublisher,
                Author = ValidAuthor,
                Status = BookStatus.Available
            },
            new BookDto
            {
                Id = 2,
                Title = "Another Title",
                Isbn = "Another Isbn",
                Publisher = "Another Publisher",
                Author = "Another author",
                Status = BookStatus.Borrowed
            },
            new BookDto
            {
                Id = 3,
                Title = "Yet another Title",
                Isbn = "Yet another Isbn",
                Publisher = "Yet another Publisher",
                Author = "Yet another Author",
                Status = BookStatus.Reserved
            }
        };

        private IBookRepository _bookRepository;
        private BookService _bookService;

        [TestInitialize]
        public void Initialize()
        {
            _bookRepository = A.Fake<IBookRepository>();

            A.CallTo(() => _bookRepository.GetByTitle(ValidTitle))
                .Returns(_books.Where(x => x.Title == ValidTitle));
            A.CallTo(() => _bookRepository.GetByAuthor(ValidAuthor))
                .Returns(_books.Where(x => x.Author == ValidAuthor));
            A.CallTo(() => _bookRepository.GetByIsbn(ValidIsbn))
                .Returns(_books.Where(x => x.Isbn == ValidIsbn));
            A.CallTo(() => _bookRepository.GetByPublisher(ValidPublisher))
                .Returns(_books.Where(x => x.Publisher == ValidPublisher));
            A.CallTo(() => _bookRepository.GetByStatus(BookStatus.Available))
                .Returns(_books.Where(x => x.Status == BookStatus.Available));
            A.CallTo(() => _bookRepository.GetByStatus(BookStatus.Borrowed))
                .Returns(_books.Where(x => x.Status == BookStatus.Borrowed));
            A.CallTo(() => _bookRepository.GetByStatus(BookStatus.Reserved))
                .Returns(_books.Where(x => x.Status == BookStatus.Reserved));

            A.CallTo(() => _bookRepository.GetByTitle(InvalidTitle))
                .Throws<BookNotFoundException>();
            A.CallTo(() => _bookRepository.GetByAuthor(InvalidAuthor))
                .Throws<BookNotFoundException>();
            A.CallTo(() => _bookRepository.GetByIsbn(InvalidIsbn))
                .Throws<BookNotFoundException>();
            A.CallTo(() => _bookRepository.GetByPublisher(InvalidPublisher))
                .Throws<BookNotFoundException>();

            A.CallTo(() => _bookRepository.CreateBook(A<BookDto>.Ignored))
                .Returns(new OperationResult
                {
                    Success = true,
                    Information = null
                });

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
            _bookService.GetByTitle(InvalidTitle);
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
            _bookService.GetByAuthor(InvalidAuthor);
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
            _bookService.GetByIsbn(InvalidIsbn);
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
            _bookService.GetByPublisher(InvalidPublisher);
        }

        [TestMethod]
        public void GetByStatus_Available_ReturnsBooks()
        {
            var result = _bookService.GetByStatus(BookStatus.Available);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Status == BookStatus.Available));
        }

        [TestMethod]
        public void GetByStatus_Reserved_ReturnsBooks()
        {
            var result = _bookService.GetByStatus(BookStatus.Reserved);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Status == BookStatus.Reserved));
        }

        [TestMethod]
        public void GetByStatus_Borrowed_ReturnsBooks()
        {
            var result = _bookService.GetByStatus(BookStatus.Borrowed);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Status == BookStatus.Borrowed));
        }

        [TestMethod]
        public void CreateBook_ValidData_ReturnsResponse()
        {
            var newbook = new BookDto
            {
                Id = 1,
                Author = "Dimitris Panokostas",
                Isbn = "1234",
                Publisher = "Some Publisher",
                Title = "My fabulous book",
                Status = BookStatus.Available
            };

            var result = _bookService.CreateBook(newbook);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (OperationResult));
            Assert.IsTrue(result.Success);
        }
    }
}