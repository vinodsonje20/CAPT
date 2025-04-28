using Application.Commands;
using CAPT_API.Tests.Mocks;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPT_API.Tests.Handler
{
    public class DeleteUserHandlerTests
    {
        private readonly Mock<IRepository<User>> _repositoryMock;

        public DeleteUserHandlerTests()
        {
            _repositoryMock = RepositoryMock.GetUserRepository();
        }

        [Fact]
        public async Task DeleteUser_ReturnsTrue_WhenUserExists()
        {
            var mockContext = new Mock<AppDbContext>();
            var handler = new DeleteUserCommandHandler(_repositoryMock.Object, mockContext.Object);

            var result = await handler.Handle(new DeleteUserCommand { Id = 2 }, CancellationToken.None);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_ReturnsFalse_WhenUserNotFound()
        {
            var mockContext = new Mock<AppDbContext>();
            var handler = new DeleteUserCommandHandler(_repositoryMock.Object, mockContext.Object);

            var result = await handler.Handle(new DeleteUserCommand { Id = 99 }, CancellationToken.None);

            Assert.False(result);
        }
    }
}
