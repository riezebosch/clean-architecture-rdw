namespace IbanChecker.Api.IntegrationTests;

public class UnitTest1
{
    [Fact]
    public async Task Test1Async()
    {
        // Arrange
        var url = "http://localhost:1234";
        await using var app = Startup.App(new[] { $"--urls={url}" });
        await app.StartAsync();

        // Act
        using var client = new HttpClient();
        using var response = await client.GetAsync($"{url}/NL25ABNA0477256600");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("true", await response.Content.ReadAsStringAsync());
    }
}