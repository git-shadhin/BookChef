using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Book GetByTitle(string title)
        {
            var bookDto = _bookRepository.GetByTitle(title);

            var book = AutoMapper.Mapper.Map<BookDto, Book>(bookDto);

            return book;
        }
    }
}
