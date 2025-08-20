using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CDN.Application.Services;
using CDN.Application.DTOs;
using CDN.Application.Interfaces;
using CDN.Domain.Entities;

namespace CDN.Freelancers.Tests.Services
{
    public class FreelancerServiceTests
    {
        private readonly Mock<IFreelancerRepository> _repoMock;
        private readonly FreelancerService _service;

        public FreelancerServiceTests()
        {
            _repoMock = new Mock<IFreelancerRepository>();
            _service = new FreelancerService(_repoMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedFreelancer()
        {
            // Arrange
            var dto = new FreelancerDto
            {
                Username = "Ali",
                Email = "ali@example.com",
                PhoneNumber = "0123456789",
                IsArchived = false,
                Skillsets = new List<string> { "C#", "SQL" },
                Hobbies = new List<string> { "Gaming" }
            };

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            Assert.Equal(dto.Username, result.Username);
            Assert.Equal(dto.Email, result.Email);
            Assert.Contains("C#", result.Skillsets);
            _repoMock.Verify(r => r.AddAsync(It.IsAny<Freelancer>()), Times.Once);
        }

        [Fact]
        public async Task ArchiveAsync_ShouldSetIsArchivedTrue()
        {
            // Arrange
            var freelancer = new Freelancer
            {
                Id = 1,
                Username = "Budi",
                Email = "budi@example.com",
                PhoneNumber = "0199999999",
                IsArchived = false
            };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(freelancer);

            // Act
            var result = await _service.ArchiveAsync(1);

            // Assert
            Assert.True(result);
            Assert.True(freelancer.IsArchived);
            _repoMock.Verify(r => r.UpdateAsync(It.IsAny<Freelancer>()), Times.Once);
        }

        [Fact]
        public async Task SearchAsync_ShouldReturnMatchingFreelancers()
        {
            // Arrange
            var data = new List<Freelancer>
            {
                new Freelancer { Id = 1, Username = "Amir", Email = "amir@test.com" },
                new Freelancer { Id = 2, Username = "Ali", Email = "ali@test.com" }
            };

            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(data);

            // Act
            var result = await _service.SearchAsync("Ali");

            // Assert
            Assert.Single(result); // hanya 1 match
            Assert.Equal("Ali", result.First().Username);
        }
    }
}
