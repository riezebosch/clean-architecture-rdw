using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using NSubstitute;

namespace IbanChecker.Api.IntegrationTests;

public sealed class UnitTest1 : IDisposable
{
    private readonly MockRepository _repository = new(MockBehavior.Strict);

    public void Dispose() => 
        _repository.VerifyAll();

    [Fact]
    public async Task Test1Async()
    {
        // Arrange
        const string iban = "NL25ABNA0477256600";
        var validator = _repository.Create<IIbanValidator>();
        validator
            .Setup(x => x.IsValid(iban))
            .Returns(true)
            .Verifiable();

        var url = new Uri("http://localhost:1234");
        await using var app = Startup.App(new[] { $"--urls={url}" }, services =>
        {
            services.RemoveAll<IIbanValidator>();
            services.AddScoped(_ => validator.Object);
        });
        app.UseDeveloperExceptionPage();

        await app.StartAsync();

        // Act
        using var client = new HttpClient
        {
            BaseAddress = url
        };
        using var response = await client.GetAsync($"/{iban}");

        // Assert
        Assert.True(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
        Assert.Equal("true", await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Test1NSubstitute()
    {
        // Arrange
        const string iban = "NL25ABNA0477256600";
        var validator = Substitute.For<IIbanValidator>();
        validator
            .IsValid(iban)
            .Returns(true);

        var url = new Uri("http://localhost:1234");
        await using var app = Startup.App(new[] { $"--urls={url}" }, services =>
        {
            services.RemoveAll<IIbanValidator>();
            services.AddScoped(_ => validator);
        });
        app.UseDeveloperExceptionPage();

        await app.StartAsync();

        // Act
        using var client = new HttpClient
        {
            BaseAddress = url
        };
        using var response = await client.GetAsync($"/{iban}");

        // Assert
        Assert.True(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
        Assert.Equal("true", await response.Content.ReadAsStringAsync());

        validator
            .Received()
            .IsValid(iban);
    }
}