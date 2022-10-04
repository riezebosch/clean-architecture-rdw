namespace IbanChecker;

public static class IbanValidator
{
    public static bool IsValid(string? iban)
    {
        return !string.IsNullOrEmpty(iban) &&
            CheckCountryCode(iban) &&
            CheckChecksum(iban) &&
            CheckBankCode(iban);
    }

    private static bool CheckCountryCode(string iban)
    {
        return iban.StartsWith("NL");
    }

    private static bool CheckChecksum(string iban)
    {
        return char.IsNumber(iban[2]) && char.IsNumber(iban[3]);
    }

    private static bool CheckBankCode(string iban)
    {
        return new[] { "ABNA" }.Contains(iban.Substring(4, 4));
    }
}