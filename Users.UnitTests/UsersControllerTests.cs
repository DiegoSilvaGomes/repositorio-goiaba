using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.API.Controllers;
using Users.API.Data.Repositories;
using Users.API.Models;
using Xunit;

namespace Users.UnitTests
{
    public class UsersControllerTests
    {
        private UsersController userController; 

        public UsersControllerTests()
        {
            userController = new UsersController(new Mock<ILogger<UsersController>>().Object, new Mock<IUserRepository>().Object);
        }

        [Fact]
        public void GetAll_Valid()
        {
            var okResult = userController.GetAll() as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_Valid()
        {
            var createUser = new User("Clark", "Kent", 34);

            var result = userController.GetById(createUser.Id);
            
            result.Equals(createUser);
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateUser_Valid()
        {

            // Arrange
            var createUser = new User("Bruce", "Wayne", 34);
            
            // Act
            
            var result = userController.CreateUser(createUser) as CreatedAtActionResult;
            var resultTest = result.Value as User;

            // Assert       

            Assert.True(resultTest.Id == createUser.Id);
            Assert.True(resultTest != null);
            Assert.IsType<User>(resultTest);
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void UpdateUser_Valid()
        {
            var createUserUpdate = new User("Diana", "Prince", 30);

            var result = userController.UpdateUser(createUserUpdate.Id, createUserUpdate);

            result.Equals(createUserUpdate);
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteUser_Valid()
        {
            var createUserDelete = new User("Hal", "Jordan", 32);

            var result = userController.DeleteUser(createUserDelete.Id);

            result.Equals(createUserDelete);
            Assert.NotNull(result);
        }
    }
}
