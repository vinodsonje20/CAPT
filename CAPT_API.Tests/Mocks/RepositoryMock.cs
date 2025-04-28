using Domain.Interfaces;
using Infrastructure.Data.Models;
using Moq;

namespace CAPT_API.Tests.Mocks
{
    public static class RepositoryMock
    {
        public static Mock<IRepository<User>> GetUserRepository()
        {
            var users = new List<User>
        {
            new User { Id = 1, Name = "Vinod", Email = "vinod@example.com" },
            new User { Id = 2, Name = "Sonje", Email = "sonje@example.com" }
        };

            var mockRepo = new Mock<IRepository<User>>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);
            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => users.FirstOrDefault(u => u.Id == id));

            // Add a new user and set Id based on the max existing Id
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<User>())).Callback((User user) =>
            {
                user.Id = users.Max(u => u.Id) + 1;  // Generate a new Id based on max Id
                users.Add(user);
                return user.Id;
            });
            
            // Update an existing user
            mockRepo.Setup(repo => repo.Update(It.IsAny<User>())).Callback((User user) =>
            {
                var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                }
            });

            // Delete a user
            mockRepo.Setup(repo => repo.Delete(It.IsAny<User>())).Callback((User user) =>
            {
                var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser != null)
                {
                    users.Remove(existingUser);
                }
            });

            return mockRepo;
        }


    }
}
