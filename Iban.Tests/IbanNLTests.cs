using BankCodeProviders.InMemory;
using System;
using Xunit;

namespace Iban.Tests
{
    public class IbanNLTests
    {
        [Fact]
        public void Validate_ValidIbanNL_True()
        {
            // Arrange
            var iban = "NL25 ABNA 0477 2566 00";

            // Act
            bool result = new IbanValidator(new Provider()).Validate(iban);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Validate_ValidIbanOtherBankCode_True()
        {
            // Arrange
            var iban = "NL25 ABNA 0477 2566 00";

            // Act
            bool result = new IbanValidator(new Provider()).Validate(iban);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Validate_ValidIbanLowerCase_True()
        {
            // Arrange
            var iban = "nl25 abna 0477 2566 00";

            // Act
            bool result = new IbanValidator(new Provider()).Validate(iban);

            // Assert
            Assert.True(result);
        }

        

        [Fact]
        public void Validate_NonAlphaNumeric_False()
        {
            // Arrange
            var iban = "NL25 ABNA 0477 2566 0%";

            // Act
            bool result = new IbanValidator(new Provider()).Validate(iban);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_InvalidBankCode_False()
        {
            // Arrange
            var iban = "NL25 XXXX 0477 2566 00";

            // Act
            bool result = new IbanValidator(new Provider()).Validate(iban);

            // Assert
            Assert.False(result);
        }
    }
}
