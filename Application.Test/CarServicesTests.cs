using Application.DTOs;
using Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Test
{
    [TestClass]
    public class CarServicesTests
    {
        IMediator mediator = new Mock<IMediator>().Object;
        IMapper mapper = new Mock<IMapper>().Object;

        [TestMethod]
        public void SendCarStatus_WhenDtoIsNull_ReturnsFalse()
        {
            //arrange
            var carService = new CarServices(mediator,mapper);

            //act
            var result = carService.SendCarStatus(null).Result;

            //assert
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void SendCarStatus_WhenCarIdIsNull_ReturnsFalse()
        {
            //arrange
            var carService = new CarServices(mediator, mapper);

            //act
            var result = carService.SendCarStatus(new CarStatusTransactionForPostDto{StatusId = 1}).Result;

            //assert
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void SendCarStatus_WhenStatusIdIsNull_ReturnsFalse()
        {
            //arrange
            var carService = new CarServices(mediator, mapper);

            //act
            var result = carService.SendCarStatus(new CarStatusTransactionForPostDto { CarId = 1 }).Result;

            //assert
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void SendCarStatus_WhenStatusNotChanged_ReturnsFalse()
        {
            //arrange
            var carService = new CarServices(mediator, mapper);

            //act
            var result = carService.SendCarStatus(new CarStatusTransactionForPostDto { CarId = 1 ,StatusId = 1}).Result;
            var result2 = carService.SendCarStatus(new CarStatusTransactionForPostDto { CarId = 1, StatusId = 1 }).Result;

            //assert
            Assert.IsTrue(result2 == false);
        }
        

    }
}
