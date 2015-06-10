using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookChef.Domain.Classes;
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
        private const string BookStatusAvailable = "Available";
        private const string BookStatusUnavailable = "Unavailable";
        private const string BookStatusReserved = "Reserved";

        private readonly List<BookDto> _books = new List<BookDto>
        {
            new BookDto
            {
                Id = 1,
                Title = ValidTitle,
                Isbn = ValidIsbn,
                Publisher = ValidPublisher,
                Author = ValidAuthor,
                StatusLabel = BookStatusAvailable
            },
            new BookDto
            {
                Id = 2,
                Title = "Another Title",
                Isbn = "Another Isbn",
                Publisher = "Another Publisher",
                Author = "Another author",
                StatusLabel = BookStatusUnavailable
            },
            new BookDto
            {
                Id = 3,
                Title = "Yet another Title",
                Isbn = "Yet another Isbn",
                Publisher = "Yet another Publisher",
                Author = "Yet another Author",
                StatusLabel = BookStatusReserved
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
            A.CallTo(() => _bookRepository.GetByStatus(BookStatusAvailable))
                .Returns(_books.Where(x => x.StatusLabel == BookStatusAvailable));
            A.CallTo(() => _bookRepository.GetByStatus(BookStatusUnavailable))
                .Returns(_books.Where(x => x.StatusLabel == BookStatusUnavailable));
            A.CallTo(() => _bookRepository.GetByStatus(BookStatusReserved))
                .Returns(_books.Where(x => x.StatusLabel == BookStatusReserved));

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
        public void GetByTitle_ValidTitle_ReturnsBooksDto()
        {
            var result = _bookService.GetByTitle(ValidTitle);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (IEnumerable<BookDto>));
            Assert.IsTrue(result.All(x => x.Title == ValidTitle));
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
            Assert.IsInstanceOfType(result, typeof (IEnumerable<BookDto>));
            Assert.IsTrue(result.All(x => x.Author == ValidAuthor));
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
            Assert.IsInstanceOfType(result, typeof (IEnumerable<BookDto>));
            Assert.IsTrue(result.All(x => x.Isbn == ValidIsbn));
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
            Assert.IsInstanceOfType(result, typeof (IEnumerable<BookDto>));
            Assert.IsTrue(result.All(x => x.Publisher == ValidPublisher));
        }

        [TestMethod, ExpectedException(typeof (BookNotFoundException))]
        public void GetByPublisher_InvalidPublisher_ThrowsException()
        {
            _bookService.GetByPublisher(InvalidPublisher);
        }

        [TestMethod]
        public void GetByStatus_Available_ReturnsBooks()
        {
            var result = _bookService.GetByStatus(BookStatusAvailable);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (IEnumerable<BookDto>));
            Assert.IsTrue(result.All(x => x.StatusLabel == BookStatusAvailable));
        }

        [TestMethod]
        public void GetByStatus_Reserved_ReturnsBooks()
        {
            var result = _bookService.GetByStatus(BookStatusReserved);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (IEnumerable<BookDto>));
            Assert.IsTrue(result.All(x => x.StatusLabel == BookStatusReserved));
        }

        [TestMethod]
        public void GetByStatus_Borrowed_ReturnsBooks()
        {
            var result = _bookService.GetByStatus(BookStatusUnavailable);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (IEnumerable<BookDto>));
            Assert.IsTrue(result.All(x => x.StatusLabel == BookStatusUnavailable));
        }

        [TestMethod]
        public void CreateBook_ValidData_ReturnsOperationResultSuccess()
        {
            A.CallTo(() => _bookRepository.CreateBook(A<BookDto>.Ignored))
                .Returns(new OperationResult
                {
                    Success = true,
                    Information = null
                });

            var result = _bookService.CreateBook(A.Dummy<BookDto>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (OperationResult));
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void ChangeBookStatus_Borrowed_ReturnsOperationResultSuccess()
        {
            A.CallTo(() => _bookRepository.ChangeBookStatus(A<BookDto>.Ignored, A<string>.Ignored))
                .Returns(new OperationResult
                {
                    Success = true,
                    Information = null
                });

            var result = _bookService.ChangeBookStatus(A.Dummy<BookDto>(), A.Dummy<string>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (OperationResult));
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void DeleteBook_ValidData_ReturnsOperationResultSuccess()
        {
            A.CallTo(() => _bookRepository.DeleteBook(A<BookDto>.Ignored))
                .Returns(new OperationResult
                {
                    Success = true,
                    Information = null
                });

            var result = _bookService.DeleteBook(A.Dummy<BookDto>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OperationResult));
            Assert.IsTrue(result.Success);
        }


    }
}