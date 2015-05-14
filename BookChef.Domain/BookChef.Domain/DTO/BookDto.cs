﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookChef.Domain.DTO
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }
}
