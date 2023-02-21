using System;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Account;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperationsAPI;
using OperationsAPI.Controllers;
using Repository;

namespace operationsApiTests
{
	public class AccountControllerTest
	{
		private readonly AccountController _controller;

        public AccountControllerTest()
		{
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            var connectionString = "server=127.0.0.1;uid=root;pwd=Chavez%123;database=operations";
            var options = new DbContextOptionsBuilder<OperationsContext>()
             .UseMySql(connectionString,
                MySqlServerVersion.LatestSupportedServerVersion)
             .Options;

            OperationsContext context = new OperationsContext(options);

            IRepositoryWrapper _repository = new RepositoryWrapper(context);
            _controller = new AccountController(_repository, mapper);
        }

        [Fact]
        public void GetOkResult()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<AccountDto>>(okResult.Value);
            Assert.True(items.Count > 1);
        }

        [Fact]
        public void GetByIdUnknownReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(0).Result;
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetByIdReturnsOneResult()
        {
            // Act
            var okResult = _controller.Get(1).Result as OkObjectResult;
            // Assert
            Assert.IsType<AccountDto>(okResult.Value);
            

        }

        [Fact]
        public void AddInvalidObjectPassedReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new AccountCreateDto()
            {
                Description = "Test Desc",
                OperationsManager = "Manager",
                ClientId = 1
            };
            _controller.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse = _controller.Post(nameMissingItem).Result;
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void AddValidObjectPassedReturnsCreatedResponse()
        {
            // Arrange
            var testItem = new AccountCreateDto()
            {
                Name = "Unit Test account",
                Description = "Test Desc",
                OperationsManager = "Manager",
                ClientId = 1
            };
            // Act
            var createdResponse = _controller.Post(testItem).Result;
            // Assert
            Assert.IsType<CreatedAtRouteResult>(createdResponse);
        }

        [Fact]
        public void AddValidObjectPassedReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new AccountCreateDto()
            {
                Name = "Unit Test account",
                Description = "Test Desc",
                OperationsManager = "Manager",
                ClientId = 1
            };
            // Act
            var createdResponse = _controller.Post(testItem).Result as CreatedAtRouteResult;
            var item = createdResponse.Value as AccountDto;
            // Assert
            Assert.IsType<AccountDto>(item);
            Assert.Equal("Unit Test account", item.Name);
        }

        [Fact]
        public void RemoveNotExistingIdPassedReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 0;
            // Act
            var badResponse = _controller.Delete(notExistingId).Result;
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void RemoveExistingIdPassedReturnsNoContentResult()
        {
            // Arrange
            var existingId = 1;
            // Act
            var noContentResponse = _controller.Delete(existingId).Result;
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void RemoveExistingIdPassedRemovesOneItem()
        {
            // Arrange
            var existingId = 7;
            var accountsResult = _controller.Get().Result as OkObjectResult;
            var accountsActive = ((List<AccountDto>)accountsResult.Value).Where(x => x.Active == 1).Count();
            // Act
            var okResponse = _controller.Delete(existingId).Result;
            var accountsResultAfterDelete = _controller.Get().Result as OkObjectResult;
            var accountsActiveAfterDelete = ((List<AccountDto>)accountsResultAfterDelete.Value).Where(x => x.Active == 1).Count();
            // Assert
            Assert.Equal(accountsActiveAfterDelete, accountsActive - 1);
        }
    }
    
}

