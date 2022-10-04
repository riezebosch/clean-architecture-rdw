namespace IbanChecker.Tests;

public class UnitTest1
{
    [Fact]
    public void IbanNull_IsFalse()
    {
        // Arrange
        string? iban = null;
        var expected = false;

        // Act
        var actual = IbanValidator.IsValid(iban);

        // Assert
        Assert.Equal(expected, actual);
    }
}