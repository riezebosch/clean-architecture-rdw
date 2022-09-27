using BankCodeProviders.InMemory;
using System;
using Xunit;

namespace Iban.Tests
{
    public class IbanValidatorTests
    {
        
        [Fact]
        public void Validate_EmptyString_False()
        {
            // Arrange
            var iban = string.Empty;

            // Act
            bool result = new IbanValidator(new Provider()).Validate(iban);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_ValidIbanCountryCodeNonSupported_False()
        {
            // Arrange
            var iban = "DE47 7002 0270 0015 5360 76";

            // Act
            bool result = new IbanValidator(new Provider()).Validate(iban);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_Null_ArgumentException()
        {
            // Arrange
            string? iban = null;

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new IbanValidator(new Provider()).Validate(iban!));

            // Assert
            Assert.Equal("iban", ex.ParamName);
        }
    }
}
