namespace IbanChecker;

public class IbanValidator
{
    private readonly IBankCodes _provider;

    public IbanValidator(IBankCodes provider)
    {
        _provider = provider;
    }

    public bool IsValid(string? iban)
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

    private bool CheckBankCode(string iban)
    { 
        return _provider
            .Get()
            .Contains(iban.Substring(4, 4));
    }
}