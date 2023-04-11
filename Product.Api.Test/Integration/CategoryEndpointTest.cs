using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Features.Command;
using Product.Infrastructure.Persistence;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Product.Api.Test.Integration
{
    public class CategoryEndpointTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CategoryEndpointTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCategories_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var scope = _factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ProductDBContext>();
            await db.Database.EnsureCreatedAsync();

            var response = await _client.GetAsync("/category");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetCategory_ShouldReturnSuccessStatusCode()
        {
            // Arrange
            var scope = _factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ProductDBContext>();
            await db.Database.EnsureCreatedAsync();

            // Arrange
            var categoryId = 1;

            // Act
            var response = await _client.GetAsync($"/category/{categoryId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddCategory_ReturnsCreatedProduct()
        {
            // Arrange
            var scope = _factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ProductDBContext>();
            await db.Database.EnsureCreatedAsync();

            var command = new AddCategoryCommand
            {
                Name = "Test Category 111",
                MinimumStock = 100
            };
            var content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/category", content);
            var entity = db.Category.FirstOrDefault(x=> x.Name == "Test Category 111");

            // Assert
            response.EnsureSuccessStatusCode();


            Assert.Equal(command.Name, entity?.Name);
            Assert.Equal(command.MinimumStock, entity?.MinimumStock);
        }
    }
}
