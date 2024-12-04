using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data_Access;
using ProductApi.Models;
using ProductApi.Repositories;
using Moq;

namespace ProductApiTests
{
    public class ProductRepositoryTests
    {
        private readonly IRepository<Product> _repository;
        private readonly Mock<DbSet<Product>> _mockSet;
        private readonly Mock<IProductDbContext> _mockContext;

        public ProductRepositoryTests()
        {
            _mockContext = new Mock<IProductDbContext>();
            _mockSet = new Mock<DbSet<Product>>();
            
            _mockContext.Setup(mc=>mc.Set<Product>()).Returns(_mockSet.Object);

            _repository = new GenericEfCoreRepository<Product>(_mockContext.Object);
        }

        [Fact]
        public async Task Get_ReturnsAsyncById()
        {
            // Arrange
            _mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync(new Product { Id = 1, Name = "test1" });

            // Act
            var result = await _repository.Get(1);

            // Assert
            Assert.NotNull(result);  // Ensure the result is not null
            Assert.Equal(1, result.Id);  // Verify the product's ID
            Assert.Equal("test1", result.Name);  // Verify the product's name
        }
    }
}
