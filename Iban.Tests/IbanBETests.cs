using Xunit;

namespace Iban.Tests
{
    public class IbanBETests
    {
        [Fact]
        public void Validate_ValidIbanBE_True()
        {
            // Arrange
            var iban = "BE27 2100 0000 2173";

            // Act
            bool result = new IbanValidator(null!).Validate(iban);

            // Assert
            Assert.True(result);
        }
    }
}
