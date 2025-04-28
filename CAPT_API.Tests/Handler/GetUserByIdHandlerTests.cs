using Application.DTOs;
using Application.Queries;
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

namespace CAPT_API.Tests.Handler
{
    public class GetUserByIdHandlerTests
    {
        private readonly Mock<IRepository<User>> _repositoryMock;
        private readonly IMapper _mapper;

        public GetUserByIdHandlerTests()
        {
            _repositoryMock = RepositoryMock.GetUserRepository();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public async Task GetUserById_ReturnsUser_WhenUserExists()
        {
            var handler = new GetUserByIdQueryHandler(_repositoryMock.Object, _mapper);

            var result = await handler.Handle(new GetUserByIdQuery { Id = 1 }, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Vinod", result.Name);
        }

        [Fact]
        public async Task GetUserById_ReturnsNull_WhenUserNotFound()
        {
            var handler = new GetUserByIdQueryHandler(_repositoryMock.Object, _mapper);

            var result = await handler.Handle(new GetUserByIdQuery { Id = 99 }, CancellationToken.None);

            Assert.Null(result);
        }
    }
}
