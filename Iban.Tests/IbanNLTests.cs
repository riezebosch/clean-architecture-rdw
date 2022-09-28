using Moq;
using NSubstitute;
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
            bool result = new IbanValidator(new StubProvider()).Validate(iban);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Validate_ValidIbanNL_True_Mock()
        {
            // Arrange
            var iban = "NL25 ABNA 0477 2566 00";

            // Act
            var provider = new MockProvider();
            _ = new IbanValidator(provider).Validate(iban);

            // Assert
            Assert.True(provider.WasCalled);
        }

        [Fact]
        public void Validate_ValidIbanNL_True_Moq()
        {
            // Arrange
            var iban = "NL25 XXXX 0477 2566 00";

            // Act
            var provider = new Mock<IBankCodeProvider>();
            provider
                .Setup(x => x.BankCodes())
                .Returns(new[] { "XXXX" })
                .Verifiable();

            var result = new IbanValidator(provider.Object).Validate(iban);

            // Assert
            provider.Verify(x => x.BankCodes(), Times.Once);
            provider.VerifyAll();
            Assert.True(result);
        }

        [Fact]
        public void Validate_ValidIbanNL_NSubstitute()
        {
            // Arrange
            var iban = "NL25 ABNA 0477 2566 00";
            
            // Act
            var provider = Substitute.For<IBankCodeProvider>();
            provider
                .BankCodes()
                .Returns(new[] { "ABNA" });

            bool result = new IbanValidator(provider).Validate(iban);

            // Assert
            Assert.True(result);
            provider.Received(1).BankCodes();
        }

        [Fact]
        public void Validate_ValidIbanOtherBankCode_True()
        {
            // Arrange
            var iban = "NL25 ABNA 0477 2566 00";

            // Act
            bool result = new IbanValidator(new StubProvider()).Validate(iban);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Validate_ValidIbanLowerCase_True()
        {
            // Arrange
            var iban = "nl25 abna 0477 2566 00";

            // Act
            bool result = new IbanValidator(new StubProvider()).Validate(iban);

            // Assert
            Assert.True(result);
        }

        

        [Fact]
        public void Validate_NonAlphaNumeric_False()
        {
            // Arrange
            var iban = "NL25 ABNA 0477 2566 0%";

            // Act
            bool result = new IbanValidator(new StubProvider()).Validate(iban);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_InvalidBankCode_False()
        {
            // Arrange
            var iban = "NL25 XXXX 0477 2566 00";

            // Act
            bool result = new IbanValidator(new StubProvider()).Validate(iban);

            // Assert
            Assert.False(result);
        }

        private class StubProvider : IBankCodeProvider
        {
            public string[] BankCodes()
            {
                return new[] { "ABNA" };
            }
        }

        private class MockProvider : IBankCodeProvider
        {
            public bool WasCalled { get; internal set; }

            public string[] BankCodes()
            {
                WasCalled = true;
                return Array.Empty<string>();
            }
        }
    }
}
