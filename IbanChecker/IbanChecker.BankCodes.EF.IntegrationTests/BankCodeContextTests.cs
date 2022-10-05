using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF.IntegrationTests;

public class BankCodeContextTests : 
    IClassFixture<DatabaseFixture>, 
    IDisposable
{
    private readonly DatabaseFixture fixture;

    public BankCodeContextTests(DatabaseFixture fixture) => 
        this.fixture = fixture;

    [Fact]
    public async Task Test1Async()
    {
        await fixture
            .Context
            .BankCodes
            .AddAsync(new BankCode { Code = "ABNA" });
        await fixture
            .Context
            .SaveChangesAsync();
    }

    [Fact]
    public async Task CodeShouldHaveMaxLength()
    {
        // Arrange
        await fixture.Context.BankCodes.AddAsync(new BankCode { Code = "ABNAX" });

        // Act
        var act = () => fixture.Context.SaveChangesAsync();

        // Assert
        var ex = await act.Should()
            .ThrowAsync<DbUpdateException>();
        ex.WithInnerException<SqlException>()
            .WithMessage("*truncate*");
    }

    void IDisposable.Dispose() => 
        fixture.Context.ChangeTracker.Clear();
}