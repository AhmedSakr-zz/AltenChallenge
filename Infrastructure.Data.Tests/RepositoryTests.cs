using Domain.Entities;
using Infrastructure.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Tests
{
    [TestClass]
    public class RepositoryTests
    {

        //Configure In memory DBContext
        private AppDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }

        [TestMethod]
        public void Add_WhenCalled_AddEntity()
        {
            //Arrange
            var mockContext = GetDatabaseContext();
            var repository = new Repository<Car>(mockContext);
            var car = new Car();

            //Act
            repository.Add(car);

            //Assert
            Assert.IsTrue(car.Id > 0);
        }

        [TestMethod]
        public void AddRange_WhenCalled_AddRangeOfEntity()
        {   //Arrange
            var mockContext = GetDatabaseContext();
            var repository = new Repository<Car>(mockContext);
            var car = new Car();
            var cars = new List<Car> { car, new Car() };
            var currentCount = repository.Queryable().CountAsync().Result;

            //Act
            repository.AddRange(cars);

            //Assert
            Assert.IsTrue(car.Id > 0);
        }

        [TestMethod]
        public void Find_WhenCalled_FindEntity()
        {
            //Arrange
            var mockContext = GetDatabaseContext();
            var repository = new Repository<Car>(mockContext);
            var car = new Car();
            repository.Add(car);

            //Act
            var result = repository.Find(car.Id);

            //Assert
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Queryable_WhenCalled_ReturnQueryableOfEntity()
        {
            //Arrange
            var mockContext = GetDatabaseContext();
            var repository = new Repository<Car>(mockContext);
            var car = new Car();
            repository.Add(car);

            //Act
            var result = repository.Queryable().CountAsync().Result;

            //Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Remove_WhenCalled_RemoveEntity()
        {
            //Arrange
            var mockContext = GetDatabaseContext();
            var repository = new Repository<Car>(mockContext);
            var countBeforeAdd = repository.Queryable().Count();
            var car = new Car { };
            repository.Add(car);

            //Act
            repository.Remove(car);
            var countAfterRemove = repository.Queryable().Count();


            //Assert
            Assert.IsTrue(countBeforeAdd == countAfterRemove);
        }
        [TestMethod]
        public void RemoveRange_WhenCalled_RemoveRangeOfEntity()
        {
            //Arrange
            var mockContext = GetDatabaseContext();
            var repository = new Repository<Car>(mockContext);
            var countBeforeAdd = repository.Queryable().Count();
            var cars = new List<Car> { new Car { }, new Car { } };
            repository.AddRange(cars);

            //Act
            repository.RemoveRange(cars);
            var countAfterRemove = repository.Queryable().Count();


            //Assert
            Assert.IsTrue(countBeforeAdd == countAfterRemove);
        }
    }
}
