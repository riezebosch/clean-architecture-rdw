using Microsoft.EntityFrameworkCore;

namespace BankCodeProviders.Database.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            await using var context = new BankCodeContext(new DbContextOptionsBuilder().UseInMemoryDatabase("test1").Options);
            context.BankCodes.Add(new BankCode { Code = "ABCD" });
            await context.SaveChangesAsync();

            var provider = new Provider(context);
            Assert.Equal(new[] { "ABCD" }, provider.BankCodes());
        }
    }
}