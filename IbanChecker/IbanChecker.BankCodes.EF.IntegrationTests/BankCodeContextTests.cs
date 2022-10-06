using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF.IntegrationTests;

public class BankCodeContextTests : 
    IClassFixture<DatabaseFixture>, 
    IDisposable
{
    private readonly DatabaseFixture _fixture;

    public BankCodeContextTests(DatabaseFixture fixture) => 
        _fixture = fixture;

    [Fact]
    public async Task Test1Async()
    {
        await _fixture
            .Context
            .BankCodes
            .AddAsync(new BankCode { Code = "ABNA" });
        await _fixture
            .Context
            .SaveChangesAsync();
    }

    [Fact]
    public async Task CodeShouldHaveMaxLength()
    {
        // Arrange
        await _fixture.Context.BankCodes.AddAsync(new BankCode { Code = "ABNAX" });

        // Act
        var act = () => _fixture.Context.SaveChangesAsync();

        // Assert
        var ex = await act.Should()
            .ThrowAsync<DbUpdateException>();
        ex.WithInnerException<SqlException>()
            .WithMessage("*truncate*");
    }

    void IDisposable.Dispose() => 
        _fixture.Context.ChangeTracker.Clear();
}