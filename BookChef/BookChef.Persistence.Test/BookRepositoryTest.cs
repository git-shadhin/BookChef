using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using BookChef.Domain.DTO;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookChef.Persistence.Test
{
    [TestClass]
    public class BookRepositoryTest
    {
        private BookRepository _bookRepository;
        private BookChefEntities _context;

        [TestInitialize]
        public void Initialize()
        {
            var books = new List<Books>
            {
                new Books
                {
                    Title = "Test Title",
                    Isbn = "12345",
                    Publisher = "Test Publisher",
                    Author = "Test Author",
                    Status = 1,
                    Id = 1
                },
                new Books
                {
                    Title = "Test Title2",
                    Isbn = "12345",
                    Publisher = "Test Publisher2",
                    Author = "Test Author2",
                    Status = 2,
                    Id = 2
                },
                new Books
                {
                    Title = "Another Title",
                    Isbn = "12345",
                    Publisher = "Another Publisher",
                    Author = "Another Author",
                    Status = 3,
                    Id = 3
                },
            };

            var statuses = new List<BookStatus>
            {
                new BookStatus
                {
                    Id = 1,
                    Label = "Available",
                    Books = books
                },
                new BookStatus
                {
                    Id = 2,
                    Label = "Reserved",
                    Books = books
                },
                new BookStatus
                {
                    Id = 3,
                    Label = "Unavailable",
                    Books = books
                }
            };

            var bookSet = A.Fake<DbSet<Books>>(o => o.Implements(typeof (IQueryable<Books>))
                .Implements(typeof (IDbAsyncEnumerable<Books>)))
                .SetupData(books);

            var statusSet = A.Fake<DbSet<BookStatus>>(o => o.Implements(typeof (IQueryable<BookStatus>))
                .Implements(typeof (IDbAsyncEnumerable<BookStatus>)))
                .SetupData(statuses);
                
            _context = A.Fake<BookChefEntities>();
            A.CallTo(() => _context.Books).Returns(bookSet);
            A.CallTo(() => _context.BookStatus).Returns(statusSet);

            _bookRepository = new BookRepository(_context);
        }

        [TestMethod]
        public void TestBookRepository_AutomapperConfiguration()
        {
            Mapper.CreateMap<Books, BookDto>();

            Mapper.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void GetByTitle_ValidTitle_ReturnsBookDtos()
        {
            const string title = "Test Title";

            var result = _bookRepository.GetByTitle(title);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(title, result.ElementAt(0).Title);
        }

        [TestMethod]
        public void GetByTitle_NonExistingTitle_ReturnsEmptyBookDtos()
        {
            const string title = "A non-existing Title";

            var result = _bookRepository.GetByTitle(title);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetByAuthor_ValidAuthor_ReturnsBookDtos()
        {
            const string author = "Test Author";

            var result = _bookRepository.GetByAuthor(author);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(author, result.ElementAt(0).Author);
        }

        [TestMethod]
        public void GetByAuthor_NonExistingAuthor_ReturnsEmptyBookDtos()
        {
            const string author = "A non-existing Author";

            var result = _bookRepository.GetByAuthor(author);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetByIsbn_ValidIsbn_ReturnsBookDtos()
        {
            const string isbn = "12345";

            var result = _bookRepository.GetByIsbn(isbn);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(isbn, result.ElementAt(0).Isbn);
        }

        [TestMethod]
        public void GetByIsbn_NonExistingIsbn_ReturnsEmptyBookDtos()
        {
            const string isbn = "6789";

            var result = _bookRepository.GetByIsbn(isbn);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetByPublisher_ValidPublisher_ReturnsBookDtos()
        {
            const string publisher = "Test Publisher";

            var result = _bookRepository.GetByPublisher(publisher);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(publisher, result.ElementAt(0).Publisher);
        }

        [TestMethod]
        public void GetByPublisher_NonExistingPublisher_ReturnsEmptyBookDtos()
        {
            const string publisher = "6789";

            var result = _bookRepository.GetByPublisher(publisher);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetByStatus_ValidStatus_ReturnsBookDtos()
        {
            const string status = "Available";

            var result = _bookRepository.GetByStatus(status);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.AreEqual(1, result.Count());
        }
    }
}
