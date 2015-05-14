using System;
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

            AutoMapper.Mapper.CreateMap<BookDto, Book>();

            _bookService = new BookService(_bookRepository);
        }

        [TestMethod]
        public void GetByTitle_ValidTitle_ReturnsBook()
        {
            const string title = "validtitle";

            var result = _bookService.GetByTitle(title);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Book));

        }
    }
}
