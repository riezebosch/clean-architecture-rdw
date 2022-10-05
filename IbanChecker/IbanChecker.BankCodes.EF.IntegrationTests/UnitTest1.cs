using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF.IntegrationTests;

public class UnitTest1 : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture database;

    public UnitTest1(DatabaseFixture database) => 
        this.database = database;

    [Fact]
    public async Task Test1Async()
    {
        await database.Context.BankCodes.AddAsync(new BankCode { Code = "ABNA" });
        await database.Context.SaveChangesAsync();
    }

    [Fact]
    public async Task CodeShouldHaveLength()
    {
        await database.Context.BankCodes.AddAsync(new BankCode { Code = "ABNAX" });
        var act = () => database.Context.SaveChangesAsync();

        var ex = await act.Should()
            .ThrowAsync<DbUpdateException>();
        ex.WithInnerException<SqlException>()
            .WithMessage("*truncate*");
    }
}