using System;
using Xunit;

namespace Iban.Tests
{
    public class IbanValidatorTests
    {
        [Fact]
        public void Validate_ValidIbanNL_True()
        {
            // Arrange
            var iban = "NL25 ABNA 0477 2566 00";

            // Act
            bool result = IbanValidatorNL.Validate(iban);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Validate_ValidIbanLowerCase_True()
        {
            // Arrange
            var iban = "nl25 abna 0477 2566 00";

            // Act
            bool result = IbanValidatorNL.Validate(iban);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Validate_EmptyString_False()
        {
            // Arrange
            var iban = string.Empty;

            // Act
            bool result = IbanValidatorNL.Validate(iban);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_ValidIbanNonNL_False()
        {
            // Arrange
            var iban = "DE47 7002 0270 0015 5360 76";

            // Act
            bool result = IbanValidatorNL.Validate(iban);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_NonAlphaNumeric_False()
        {
            // Arrange
            var iban = "NL25 ABNA 0477 2566 0%";

            // Act
            bool result = IbanValidatorNL.Validate(iban);

            // Assert
            Assert.False(result);
        }
    }
}
