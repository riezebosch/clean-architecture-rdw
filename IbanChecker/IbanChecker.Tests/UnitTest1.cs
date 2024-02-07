namespace IbanChecker.Tests;

public class UnitTest1
{
    [Fact]
    public void IbanNull_IsFalse()
    {
        // Arrange
        string? iban = null;

        // Act
        var actual = new IbanValidator(new BankCodes.InMemory.Adapter()).IsValid(iban);

        // Assert
        actual
            .FailToSeq()
            .Should()
            .BeEquivalentTo("Input is empty");
    }

    [Fact]
    public void ValidIban_IsTrue()
    {
        // Arrange
        var iban = "NL25ABNA0477256600";

        // Act
        var actual = new IbanValidator(new BankCodes.InMemory.Adapter()).IsValid(iban);

        // Assert
        Assert.True(actual.IsSuccess);
    }

    [Fact]
    public void EmptyString_IsFalse()
    {
        // Arrange
        var iban = string.Empty;

        // Act
        var actual = new IbanValidator(new BankCodes.InMemory.Adapter()).IsValid(iban);

        // Assert
        Assert.True(actual.IsFail);
    }

    [Fact]
    public void CountryCodeNotNL_IsFalse()
    {
        // Arrange
        var iban = "XX25ABNA0477256600";

        // Act
        var actual = new IbanValidator(new BankCodes.InMemory.Adapter()).IsValid(iban);

        // Assert
        actual
            .FailAsEnumerable()
            .Should()
            .BeEquivalentTo("Dutch iban should start with NL");
    }

    [Fact]
    public void CheckChecksumInvalid_IsFalse()
    {
        // Arrange
        var iban = "NLXXABNA0477256600";

        // Act
        var actual = new IbanValidator(new BankCodes.InMemory.Adapter()).IsValid(iban);

        // Assert
        actual
            .FailToSeq()
            .Should()
            .BeEquivalentTo("Checksum should consist out of 2 digits");
    }

    [Fact]
    public void Check2ndDigitsInvalid_IsFalse() => 
        new IbanValidator(new BankCodes.InMemory.Adapter())
            .IsValid("NL0XABNA0477256600")
            .IsSuccess
            .Should()
            .BeFalse();

    [Fact]
    public void BankCodeInvalid_IsFalse() =>
    new IbanValidator(new BankCodes.InMemory.Adapter())
        .IsValid("NL25XXXX0477256600")
        .IsSuccess
        .Should()
        .BeFalse();
}