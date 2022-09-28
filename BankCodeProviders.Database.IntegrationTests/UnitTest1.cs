using Microsoft.EntityFrameworkCore;

namespace BankCodeProviders.Database.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1Async()
        {
            // Arrange
            using var context = new BankCodeContext(new DbContextOptionsBuilder().UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=bankcodes;Integrated Security=SSPI;").Options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            context.BankCodes.Add(new BankCode 
            { 
                Code = "ABNA" 
            });

            await context.SaveChangesAsync();
        }
    }
}