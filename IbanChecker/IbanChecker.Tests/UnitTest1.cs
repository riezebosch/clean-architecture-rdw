using FluentAssertions;

namespace IbanChecker.Tests;

public class UnitTest1
{
    [Fact]
    public void IbanNull_IsFalse()
    {
        // Arrange
        string? iban = null;

        // Act
        var actual = IbanValidator.IsValid(iban);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void ValidIban_IsTrue()
    {
        // Arrange
        var iban = "NL25ABNA0477256600";

        // Act
        var actual = IbanValidator.IsValid(iban);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void EmptyString_IsFalse()
    {
        // Arrange
        var iban = string.Empty;

        // Act
        var actual = IbanValidator.IsValid(iban);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CountryCodeNotNL_IsFalse()
    {
        // Arrange
        var iban = "XX25ABNA0477256600";

        // Act
        var actual = IbanValidator.IsValid(iban);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CheckChecksumInvalid_IsFalse()
    {
        // Arrange
        var iban = "NLXXABNA0477256600";

        // Act
        var actual = IbanValidator.IsValid(iban);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Check2ndDigitsInvalid_IsFalse() => 
        IbanValidator
            .IsValid("NL0XABNA0477256600")
            .Should()
            .BeFalse();

    [Fact]
    public void BankCodeInvalid_IsFalse() =>
    IbanValidator
        .IsValid("NL25XXXX0477256600")
        .Should()
        .BeFalse();
}