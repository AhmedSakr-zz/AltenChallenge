using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DomainEventHandlers;
using Application.DTOs;
using AutoMapper;
using Infrastructure.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Test
{
    [TestClass]
    public class CarQueryHandlerTests
    {
        [TestMethod]
        public void handle_WhenCalled_ReturnsList()
        {
            //arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(databaseContext);
             
            var handler = new CarQueryHandler(unitOfWork);

            //act
            var result = handler.Handle(new CarQueryDto{StatusId = 0,CustomerId = 0},
                new System.Threading.CancellationToken()).Result;
           

            //assert
            Assert.IsTrue(result.Any());
        }
    }
}
