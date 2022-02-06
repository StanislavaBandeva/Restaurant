using FluentAssertions;
using Moq;
using Restaurant.BL.Services;
using Restaurant.DL.Interfaces;
using Restaurant.Models.DTO;
using Restaurant.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Restaurant.Test.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;

        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();

            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public void ProductService_GetAll_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = ProductType.Coffee,
                    Price = 1.00m,
                },
                new Product
                {
                    Id = 2,
                    Name = ProductType.Pizza,
                    Price = 100.00m,
                }
            };

            _productRepositoryMock
                .Setup(r => r.GetAll())
                .Returns(products);

            // Act
            var result = _productService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(products);
            result.Count().Should().Be(2);
        }

        [Fact]
        public void ProductService_GetById_ShouldReturnProductById()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            _productRepositoryMock
                .Setup(r => r.GetById(product.Id))
                .Returns(product);

            // Act
            var result = _productService.GetById(product.Id);

            // Assert
            result.Should().Be(product);
        }

        [Fact]
        public void ProductService_Delete_ShouldReturnDeletedProduct()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            _productRepositoryMock
                .Setup(r => r.Delete(product.Id))
                .Returns(product);

            // Act
            var result = _productService.Delete(product.Id);

            // Assert
            result.Should().Be(product);
        }

        [Fact]
        public void ProductService_Create_ShouldReturnCreatedProduct()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            _productRepositoryMock
                .Setup(r => r.Create(product))
                .Returns(product);

            // Act
            var result = _productService.Create(product);

            // Assert
            result.Should().Be(product);
        }

        [Fact]
        public void ProductService_Update_ShouldReturnUpdatedProduct()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            _productRepositoryMock
                .Setup(r => r.Update(product))
                .Returns(product);

            // Act
            var result = _productService.Update(product);

            // Assert
            result.Should().Be(product);
        }
    }
}
