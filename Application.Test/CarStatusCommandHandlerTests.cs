using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTOs;
using Infrastructure.Data.Contracts;
using Infrastructure.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Test
{
    [TestClass]
    public class CarStatusCommandHandlerTests
    {
        [TestMethod]
        public void Handle_WhenRequestIsNull_ReturnsFalse()
        {
            //arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var handler = new CarStatusCommandHandler(unitOfWork.Object);

            //act
            var result = handler.Handle(null, new System.Threading.CancellationToken()).Result;

            //assert
            Assert.IsTrue(result==false);

        } 
        [TestMethod]
        public void Handle_WhenCarIsNotExists_ReturnsFalse()
        {
            //arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(databaseContext);
            var handler = new CarStatusCommandHandler(unitOfWork);

            //act
            var result = handler.Handle(new CarStatusTransactionForPostDto {CarId = 0, StatusId = 1},
                new System.Threading.CancellationToken()).Result;

            //assert
            Assert.IsTrue(result==false);

        }
        [TestMethod]
        public void Handle_WhenStatusNotChanged_ReturnsFalse()
        {
            //arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(databaseContext);
            var handler = new CarStatusCommandHandler(unitOfWork);

            //act
            var result = handler.Handle(new CarStatusTransactionForPostDto { CarId = 1, StatusId = 1 },
                new System.Threading.CancellationToken()).Result;
            var result2 = handler.Handle(new CarStatusTransactionForPostDto { CarId = 1, StatusId = 1 },
                new System.Threading.CancellationToken()).Result;

            //assert
            Assert.IsTrue(result2 == false);

        }
        [TestMethod]
        public void Handle_WhenStatusChange_ReturnsTrue()
        {
            //arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(databaseContext);
            var handler = new CarStatusCommandHandler(unitOfWork);

            //act
            var result = handler.Handle(new CarStatusTransactionForPostDto { CarId = 1, StatusId = 1 },
                new System.Threading.CancellationToken()).Result;
            var result2 = handler.Handle(new CarStatusTransactionForPostDto { CarId = 1, StatusId = 2 },
                new System.Threading.CancellationToken()).Result;

            //assert
            Assert.IsTrue(result2 == true);

        }
    }
}
