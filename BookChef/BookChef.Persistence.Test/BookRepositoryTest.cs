using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookChef.Domain.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookChef.Persistence.Test
{
    [TestClass]
    public class BookRepositoryTest
    {
        private BookRepository _bookRepository;

        [TestInitialize]
        public void Initialize()
        {
            _bookRepository = new BookRepository();
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
            const string title = "Test";

            var result = _bookRepository.GetByTitle(title);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetByAuthor_ValidAuthor_ReturnsBookDtos()
        {
            const string author = "Test";

            var result = _bookRepository.GetByAuthor(author);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<BookDto>));
            Assert.IsTrue(result.Any());
        }
    }
}
