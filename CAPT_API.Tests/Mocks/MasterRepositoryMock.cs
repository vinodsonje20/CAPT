using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPT_API.Tests.Mocks
{
    public static class MasterRepositoryMock<TEntity> where TEntity : class
    {
        public static Mock<IGenericRepository<TEntity>> GetMockRepository(List<TEntity> data)
        {
            var mockRepo = new Mock<IGenericRepository<TEntity>>();

            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(data);

            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => data.FirstOrDefault(d => ((dynamic)d).Id == id));

            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<TEntity>()))
                .Callback<TEntity>(e => data.Add(e));

            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<TEntity>()))
                .Callback<TEntity>(e => { /* update logic can be added if needed */ });

            mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<TEntity>()))
                .Callback<TEntity>(e => data.Remove(e));

            mockRepo.Setup(repo => repo.SaveChangesAsync());

            return mockRepo;
        }
    }
}
