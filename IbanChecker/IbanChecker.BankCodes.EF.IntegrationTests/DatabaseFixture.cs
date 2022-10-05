using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF.IntegrationTests;

public class DatabaseFixture : IAsyncLifetime
{
    public BankCodeContext Context { get; private set; }

    public DatabaseFixture()
    {
        Context = new BankCodeContext(new DbContextOptionsBuilder().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=test").Options); ;
    }

    public async Task InitializeAsync()
    {
        await Context.Database.EnsureDeletedAsync();
        await Context.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync() => 
        await Context.DisposeAsync();
}