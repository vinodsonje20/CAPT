using Xunit;
using Moq;
using AutoMapper;
using Application.DTOs;
using Application.Queries;
using CAPT_API.Tests.Mocks;
using Domain.Interfaces;
using Infrastructure.Data.Models;

namespace CAPT_API.Tests.Handler
{
    public class GetAllUsersHandlerTests
    {
        private readonly Mock<IRepository<User>> _repositoryMock;
        private readonly IMapper _mapper;

        public GetAllUsersHandlerTests()
        {
            _repositoryMock = RepositoryMock.GetUserRepository();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public async Task GetAllUsers_ReturnsListOfUsers()
        {
            var handler = new GetAllUsersQueryHandler(_repositoryMock.Object, _mapper);

            var result = await handler.Handle(new GetAllUsersQuery(), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
