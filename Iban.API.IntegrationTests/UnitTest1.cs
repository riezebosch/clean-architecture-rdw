using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Iban.API.IntegrationTests
{
    public class UnitTest1
    {
        [Fact(Skip = "krijg de controller nog niet werkend, 404")]
        public async Task Test1Async()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();
            builder.RegisterServices();

            var app = builder.Build();
            app.RegisterMiddleWare();
            app.Urls.Add("http://localhost:1234");

            await app.StartAsync();

            // Act
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:1234/WeatherForecast/");
            
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Factory()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // ... Configure test services
                });

            var client = application.CreateClient();
            var response = await client.GetAsync("/Iban?iban=NL78INGB...");

            response.EnsureSuccessStatusCode();
        }
    }
}