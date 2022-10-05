using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace IbanChecker.BankCodes.EF.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            // Arrange
            await using var context = new BankCodeContext(new DbContextOptionsBuilder().UseInMemoryDatabase("test").Options);
            await context.BankCodes.AddAsync(new BankCode { Code = "1234" });
            await context.SaveChangesAsync();
            var result = new Adapter(context).Get();

            result.Should().BeEquivalentTo("1234");
        }
    }
}