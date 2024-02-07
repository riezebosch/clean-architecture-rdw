namespace IbanChecker.Tests;

public static class DataDrivenDemo
{

    [Theory]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData("NL25ABNA0477256600", true)]
    public static void EmptyString_IsFalse(string iban, bool expected)
    {
        // Arrange

        // Act
        var actual = new IbanValidator(new BankCodes.InMemory.Adapter()).IsValid(iban);

        // Assert
        Assert.Equal(expected, actual.IsSuccess);
    }
}