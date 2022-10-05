using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF.IntegrationTests;

public class UnitTest1 : IAsyncLifetime
{
    private readonly BankCodeContext context;

    public UnitTest1()
    {
        context = new BankCodeContext(new DbContextOptionsBuilder().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=test").Options); ;
    }

    public async Task InitializeAsync()
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync() =>
        await context.DisposeAsync();

    [Fact]
    public async Task Test1Async()
    {
        await context.BankCodes.AddAsync(new BankCode { Code = "ABNA" });
        await context.SaveChangesAsync();
    }

    [Fact]
    public async Task CodeShouldHaveLength()
    {
        await context.BankCodes.AddAsync(new BankCode { Code = "ABNAX" });
        var act = () => context.SaveChangesAsync();

        var ex = await act.Should()
            .ThrowAsync<DbUpdateException>();
        ex.WithInnerException<SqlException>()
            .WithMessage("*truncate*");
    }
}