using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1Async()
        {
            await using var context = new BankCodeContext(new DbContextOptionsBuilder().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=test").Options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            await context.BankCodes.AddAsync(new BankCode { Code = "ABNA" } );
            await context.SaveChangesAsync();
        }
    }
}