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
    public class UpdateUserHandlerTests
    {
        private readonly Mock<IRepository<User>> _repositoryMock;
        

        public UpdateUserHandlerTests()
        {
            _repositoryMock = RepositoryMock.GetUserRepository();
        }

        [Fact]
        public async Task UpdateUser_ReturnsTrue_WhenUserExists()
        {
            var mockContext = new Mock<AppDbContext>();

            var handler = new UpdateUserCommandHandler(_repositoryMock.Object, mockContext.Object);

            var result = await handler.Handle(new UpdateUserCommand
            {
                Id = 1,
                Name = "Vinod Updated",
                Email = "vinod_updated@example.com"
            }, CancellationToken.None);

            Assert.True(result);
        }

        [Fact]
        public async Task UpdateUser_ReturnsFalse_WhenUserNotFound()
        {
            var mockContext = new Mock<AppDbContext>();
            var handler = new UpdateUserCommandHandler(_repositoryMock.Object, mockContext.Object);
            var result = await handler.Handle(new UpdateUserCommand
            {
                Id = 99,
                Name = "Doesn't Matter",
                Email = "noone@example.com"
            }, CancellationToken.None);

            Assert.False(result);
        }
    }

}
