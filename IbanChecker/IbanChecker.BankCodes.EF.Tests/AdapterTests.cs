using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF.Tests;

public class AdapterTests
{
    [Fact]
    public async void GetReturnsBankCodesFromContext()
    {
        // Arrange
        await using var context = new BankCodeContext(new DbContextOptionsBuilder().UseInMemoryDatabase("test").Options);
        await context.BankCodes.AddAsync(new BankCode { Code = "1234" });
        await context.SaveChangesAsync();

        // Act
        var result = new Adapter(context).Get();

        // Assert
        result.Should().BeEquivalentTo("1234");
    }
}