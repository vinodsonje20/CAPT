using Application.Commands;
using AutoMapper;
using CAPT_API.Tests.Mocks;
using Domain.Interfaces;
using Infrastructure.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.Language.Flow;
using Infrastructure.Data;

namespace CAPT_API.Tests.Handler
{
    public class AddUserHandlerTests
    {
        private readonly Mock<IRepository<User>> _repositoryMock;

        public AddUserHandlerTests()
        {
            _repositoryMock = RepositoryMock.GetUserRepository();
        }

        [Fact]
        public async Task Handle_ValidUser_ReturnsNewUserId()
        {
            var mockContext = new Mock<AppDbContext>();

            // Arrange
            var command = new CreateUserCommand
            {
                Name = "John",
                Email = "john.doe@example.com"
            };

            var expectedUserId = 123;

            _repositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<User>()));

            var handler = new CreateUserCommandHandler(_repositoryMock.Object, mockContext.Object);
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(expectedUserId, result);

            _repositoryMock.Verify(repo => repo.AddAsync(It.Is<User>(u =>
                u.Name == "John" &&
                u.Email == "john.doe@example.com"
            )), Times.Once);
        }
    }
}
