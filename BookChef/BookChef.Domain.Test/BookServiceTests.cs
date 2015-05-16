using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookChef.Domain.DTO;
using BookChef.Domain.Interfaces;
using BookChef.Domain.Services;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookChef.Domain.Test
{
    [TestClass]
    public class BookServiceTests
    {
        private IBookRepository _bookRepository;
        private BookService _bookService;

        [TestInitialize]
        public void Initialize()
        {
            _bookRepository = A.Fake<IBookRepository>();

            Mapper.CreateMap<BookDto, Book>();

            _bookService = new BookService(_bookRepository);
        }

        [TestMethod]
        public void GetByTitle_ValidTitle_ReturnsBooks()
        {
            const string titleToSearch = "validtitle";

            A.CallTo(() => _bookRepository.GetByTitle(titleToSearch))
                .Returns(new List<BookDto>
                {
                    new BookDto
                    {
                        BookId = 1,
                        Author = "John Smith Jr.",
                        Isbn = "1234-567",
                        Publisher = "Space Publications",
                        Title = titleToSearch
                    }
                });

            var result = _bookService.GetByTitle(titleToSearch);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Title == titleToSearch));
        }

        [TestMethod]
        public void GetByAuthor_ValidAuthor_ReturnsBooks()
        {
            const string authorToSearch = "Homer";

            var books = new List<BookDto>
            {
                new BookDto
                {
                    BookId = 1,
                    Title = "Odyssey",
                    Isbn = "12345",
                    Publisher = "Someone",
                    Author = "Homer"
                },
                new BookDto
                {
                    BookId = 2,
                    Title = "Ilyad",
                    Isbn = "67890",
                    Publisher = "Someone",
                    Author = "Homer"
                }
            };

            A.CallTo(() => _bookRepository.GetByAuthor(authorToSearch))
                .Returns(books);

            var result = _bookService.GetByAuthor(authorToSearch);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Author == authorToSearch));
        }

        [TestMethod]
        public void GetByIsbn_ValidIsbn_ReturnsBooks()
        {
            const string isbnToSearch = "123456";

            A.CallTo(() => _bookRepository.GetByIsbn(isbnToSearch))
                .Returns(new List<BookDto>
                {
                    new BookDto
                    {
                        BookId = 1,
                        Title = "Odyssey",
                        Isbn = "123456",
                        Publisher = "Someone",
                        Author = "Homer"
                    }
                });

            var result = _bookService.GetByIsbn(isbnToSearch);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Isbn == isbnToSearch));
        }

        [TestMethod]
        public void GetByPublisher_ValidPublisher_ReturnsBooks()
        {
            const string publisherToSearch = "Someone";

            A.CallTo(() => _bookRepository.GetByPublisher(publisherToSearch))
                .Returns(new List<BookDto>
                {
                    new BookDto
                    {
                        BookId = 1,
                        Title = "Odyssey",
                        Isbn = "123456",
                        Publisher = "Someone",
                        Author = "Homer"
                    }
                });

            var result = _bookService.GetByPublisher(publisherToSearch);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (List<Book>));
            Assert.IsTrue(result.Any(x => x.Publisher == publisherToSearch));
        }
    }
}