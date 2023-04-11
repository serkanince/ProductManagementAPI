//using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Features.Command;
using Product.Infrastructure.Persistence;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Product.Api.Test.Integration
{
    public class ProductEndpointTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public ProductEndpointTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetProduct_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var productId = 1;

            // Act
            var response = await _client.GetAsync($"/product/{productId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddProduct_ReturnsCreatedProduct()
        {
            // Arrange
            var scope = _factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ProductDBContext>();
            await db.Database.EnsureCreatedAsync();

            var command = new AddProductCommand
            {
                Title = "Test Product 111",
                Description = "This is a test product",
                CategoryId = 1,
                Stock = 10,
                Price = 1,
            };
            var content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/product", content);
            var entity = db.Products.FirstOrDefault(x=> x.Title == "Test Product 111");

            // Assert
            response.EnsureSuccessStatusCode();
            

            Assert.Equal(command.Title, entity?.Title);
            Assert.Equal(command.Description, entity?.Description);
            Assert.Equal(command.CategoryId, entity?.CategoryId);
            Assert.Equal(command.Stock, entity?.Stock);
            Assert.Equal(command.Price, entity?.Price);
        }

    }
}
