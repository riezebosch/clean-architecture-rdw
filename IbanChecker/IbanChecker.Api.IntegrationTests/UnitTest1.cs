using Microsoft.AspNetCore.Builder;

namespace IbanChecker.Api.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1Async()
        {
            var args = new[] { "--urls=http://localhost:1234" };
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            using var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();



            app.MapGet("/", () => "hello");

            await app.StartAsync();

            using var client = new HttpClient();
            using var response = await client.GetAsync("http://localhost:1234");

            response.EnsureSuccessStatusCode();

            Assert.Equal("hello", await response.Content.ReadAsStringAsync());
        }
    }
}