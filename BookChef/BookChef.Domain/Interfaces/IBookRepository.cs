using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookChef.Domain.DTO;

namespace BookChef.Domain.Interfaces
{
    public interface IBookRepository
    {
        BookDto GetByTitle(string booktitle);
    }
}
