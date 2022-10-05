using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace IbanChecker.Api.IntegrationTests;

public sealed class UnitTest1 : IDisposable
{
    private readonly MockRepository repository = new(MockBehavior.Strict);

    public void Dispose() => 
        repository.VerifyAll();

    [Fact]
    public async Task Test1Async()
    {
        // Arrange
        const string iban = "NL25ABNA0477256600";
        var validator = repository.Create<IIbanValidator>();
        validator
            .Setup(x => x.IsValid(iban))
            .Returns(true)
            .Verifiable();

        var url = "http://localhost:1234";
        await using var app = Startup.App(new[] { $"--urls={url}" }, services =>
        {
            services.RemoveAll<IIbanValidator>();
            services.AddScoped(_ => validator.Object);
        });
        app.UseDeveloperExceptionPage();

        await app.StartAsync();

        // Act
        using var client = new HttpClient();
        using var response = await client.GetAsync($"{url}/{iban}");

        // Assert
        Assert.True(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
        Assert.Equal("true", await response.Content.ReadAsStringAsync());
    }
}