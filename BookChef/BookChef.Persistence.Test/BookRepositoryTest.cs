﻿using System;
using AutoMapper;
using BookChef.Domain.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookChef.Persistence.Test
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void TestAutomapperConfiguration()
        {
            Mapper.CreateMap<Books, BookDto>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}
