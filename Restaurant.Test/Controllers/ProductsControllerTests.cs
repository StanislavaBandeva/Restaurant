using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Restaurant.BL.Interfaces;
using Restaurant.Host.Controllers;
using Restaurant.Host.Extensions;
using Restaurant.Models.DTO;
using Restaurant.Models.Enums;
using Restaurant.Models.Requests;
using System.Collections.Generic;
using Xunit;

namespace Restaurant.Test.Controllers
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<ProductsController>> _loggerMock;

        private readonly ProductsController _productController;

        public ProductsControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _loggerMock = new Mock<ILogger<ProductsController>>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _productController = new ProductsController(
                _productServiceMock.Object,
                _mapper,
                _loggerMock.Object);
        }

        [Fact]
        public void ProductsController_GetAll_ShouldReturnAllProductsWith200OkStatusCode()
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

            _productServiceMock
                .Setup(x => x.GetAll())
                .Returns(products);

            // Act
            var result = _productController.GetAll();
            var okObjectResult = result as OkObjectResult;

            // Assert
            okObjectResult.StatusCode.Should().Be(200);
            okObjectResult.Value.Should().BeEquivalentTo(products);
        }

        [Fact]
        public void ProductsController_GetAll_ShouldReturn204NoContentStatusCode()
        {
            // Arrange
            _productServiceMock
                .Setup(x => x.GetAll())
                .Returns((List<Product>)null);

            // Act
            var result = _productController.GetAll();
            var noContentResult = result as NoContentResult;

            // Assert
            noContentResult.StatusCode.Should().Be(204);
        }

        [Fact]
        public void ProductsController_GetById_ShouldReturnProductByIdWith200OkStatusCode()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            _productServiceMock
                .Setup(x => x.GetById(product.Id))
                .Returns(product);

            // Act
            var result = _productController.Get(product.Id);
            var okObjectResult = result as OkObjectResult;

            // Assert
            okObjectResult.StatusCode.Should().Be(200);
            okObjectResult.Value.Should().BeEquivalentTo(product);
        }

        [Fact]
        public void ProductsController_GetById_ShouldReturn404NotFoundStatusCode()
        {
            // Arrange
            _productServiceMock
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns((Product)null);

            // Act
            var result = _productController.Get(It.IsAny<int>());
            var notFoundObjectResult = result as NotFoundObjectResult;

            // Assert
            notFoundObjectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public void ProductsController_Create_ShouldReturnCreatedProductWith200OkStatusCode()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            var productRequest = new ProductRequest
            {
                Name = product.Name,
                Price = product.Price,
            };

            _productServiceMock
                .Setup(x => x.Create(It.IsAny<Product>()))
                .Returns(product);

            // Act
            var result = _productController.Create(productRequest);
            var okObjectResult = result as OkObjectResult;

            // Assert
            okObjectResult.StatusCode.Should().Be(200);
            okObjectResult.Value.Should().BeEquivalentTo(product);
        }

        [Fact]
        public void ProductsController_Create_ShouldReturn400BadRequestStatusCode()
        {
            // Act
            var result = _productController.Create(null);
            var badRequestObjectResult = result as BadRequestResult;

            // Assert
            badRequestObjectResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public void ProductsController_Delete_ShouldReturnDeletedProductWith200OkStatusCode()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            _productServiceMock
                .Setup(x => x.Delete(product.Id))
                .Returns(product);

            // Act
            var result = _productController.Delete(product.Id);
            var okObjectResult = result as OkObjectResult;

            // Assert
            okObjectResult.StatusCode.Should().Be(200);
            okObjectResult.Value.Should().BeEquivalentTo(product);
        }

        [Fact]
        public void ProductsController_Delete_ShouldReturn400BadRequestStatusCode()
        {
            // Arrange
            var id = -1;

            // Act
            var result = _productController.Delete(id);
            var badRequestResult = result as BadRequestObjectResult;

            // Assert
            badRequestResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public void ProductsController_Delete_ShouldReturn404NotFoundStatusCode()
        {
            // Arrange
            var id = 1;

            _productServiceMock
                .Setup(x => x.Delete(id))
                .Returns((Product)null);

            // Act
            var result = _productController.Delete(id);
            var notFoundObjectResult = result as NotFoundObjectResult;

            // Assert
            notFoundObjectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public void ProductsController_Update_ShouldReturnUpdatedProductWith200OkStatusCode()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            var updatedProduct = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 3.00m,
            };

            _productServiceMock
                .Setup(x => x.GetById(product.Id))
                .Returns(product);

            _productServiceMock
                .Setup(x => x.Update(updatedProduct))
                .Returns(updatedProduct);

            // Act
            var result = _productController.Update(updatedProduct);
            var okObjectResult = result as OkObjectResult;

            // Assert
            okObjectResult.StatusCode.Should().Be(200);
            okObjectResult.Value.Should().BeEquivalentTo(updatedProduct);
        }

        [Fact]
        public void ProductsController_Update_ShouldReturn400BadRequestStatusCode()
        {
            // Act
            var result = _productController.Update(null);
            var badRequestObjectResult = result as BadRequestResult;

            // Assert
            badRequestObjectResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public void ProductsController_Update_ShouldReturn404NotFoundStatusCodeWhenGetByIdReturnsNull()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            _productServiceMock
                .Setup(x => x.GetById(product.Id))
                .Returns((Product)null);

            // Act
            var result = _productController.Update(product);
            var notFoundObjectResult = result as NotFoundObjectResult;

            // Assert
            notFoundObjectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public void ProductsController_Update_ShouldReturn404NotFoundStatusCodeWhenUpdateReturnsNull()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 1.00m,
            };

            var updatedProduct = new Product
            {
                Id = 1,
                Name = ProductType.Coffee,
                Price = 3.00m,
            };

            _productServiceMock
                .Setup(x => x.GetById(product.Id))
                .Returns(product);

            _productServiceMock
                .Setup(x => x.Update(updatedProduct))
                .Returns((Product)null);

            // Act
            var result = _productController.Update(updatedProduct);
            var notFoundObjectResult = result as NotFoundObjectResult;

            // Assert
            notFoundObjectResult.StatusCode.Should().Be(404);
        }
    }
}
