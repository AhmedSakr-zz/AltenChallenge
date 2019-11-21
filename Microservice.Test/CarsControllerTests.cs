using Application.Contracts;
using Application.DTOs;
using Microservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Microservice.Test
{
    [TestClass]
    public class CarsControllerTests
    {
        ICarServices carServices = new Mock<ICarServices>().Object;
        IFakeSendCarStatusServices sendCarStatusServices = new Mock<IFakeSendCarStatusServices>().Object;


        [TestMethod]
        public void GetCars_WhenDtoIsNull_ReturnsNoContentResult()
        {
            //arrange
            var carsController=new CarsController(carServices,sendCarStatusServices);

            //act
            var result = carsController.GetCars(null).Result;

            //assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void GetCars_WhenDtoNotNull_ReturnsJSon()
        {
            //arrange
            var carsController = new CarsController(carServices, sendCarStatusServices);

            //act
            var result = carsController.GetCars(new CarQueryDto()).Result;

            //assert
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public void GetCustomers_WhenCalled_ReturnsJSon()
        {
            //arrange
            var carsController = new CarsController(carServices, sendCarStatusServices);

            //act
            var result = carsController.GetCustomers().Result;

            //assert
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        //[TestMethod]
        //public void StartTask_WhenCalled_ReturnsJSon()
        //{
        //    //arrange
        //    var carsController = new CarsController(carServices, sendCarStatusServices);

        //    //act
        //    var result = carsController.StartTask();

        //    //assert
        //    Assert.IsInstanceOfType(result, typeof(JsonResult));
        //}


    }
}
