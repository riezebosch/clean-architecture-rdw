using FluentAssertions;
using System.Numerics;

namespace IbanChecker.Tests;

public static class Checksum
{
    [Theory]
    [InlineData("NL25ABNA0477256600")]
    [InlineData("BE27210000002173")]
    public static void Test1(string iban)
    {
        Validate(iban).Should().BeTrue();
    }

    private static bool Validate(string iban) =>
        iban.ToNumber() % 97 == 1;

    private static BigInteger ToNumber(this string iban) =>
        BigInteger.Parse(iban.ToDigits());

    private static string ToDigits(this string iban) =>
        string.Join("", iban.Rearrange().Select(ToDigits));

    private static int ToDigits(char c) =>
        char.IsLetter(c)
        ? c - 'A' + 10
        : c - '0';

    private static string Rearrange(this string iban) =>
        $"{iban[4..]}{iban[..4]}";
}
